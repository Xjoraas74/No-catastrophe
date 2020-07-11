using UnityEngine;
using UnityEngine.SceneManagement;

public class BlameMenu : MonoBehaviour
{
    float lastPointOfTrust = .03f;
    bool continueBlaming;
    int index;

    void Awake()
    {
        GameObject.Find("Game manager").GetComponent<GameManager>().blameMenu = gameObject;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && continueBlaming)
        {
            if (index - 5 != 1)
            {
                SceneManager.LoadScene("Bad end");
            }
            else
            {
                SceneManager.LoadScene("Good end");
            }
        }
    }

    public void Blame(string nameOfGuilty)
    {
        switch (nameOfGuilty)
        {
            case "Alice":
                index = 0;
                break;
            case "Bob":
                index = 1;
                break;
            case "Christopher":
                index = 2;
                break;
            case "Daniel":
                index = 3;
                break;
            case "Emily":
                index = 4;
                break;
        }

        GameObject.Find("Game manager").GetComponent<GameManager>().PrepareBlame();
        if (GameObject.Find("Game manager").GetComponent<GameManager>().guiltySlider[index] > lastPointOfTrust)
        {
            index += 5;
            gameObject.GetComponent<Dialog>().TypeSentenceByNumber(index);
            continueBlaming = true;
        }
        else
        {
            gameObject.GetComponent<Dialog>().TypeSentenceByNumber(index);
        }
    }
}