using UnityEngine;

public class BlameMenu : MonoBehaviour
{
    float lastPointOfTrust = 50f;
    bool continueBlaming;

    void Awake()
    {
        GameObject.Find("Game manager").GetComponent<GameManager>().blameMenu = gameObject;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || continueBlaming)
        {
            // do what happens after blaming itself
        }
    }

    public void Blame(string nameOfGuilty)
    {
        int index = 0;
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