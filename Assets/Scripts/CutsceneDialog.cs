using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class CutsceneDialog : MonoBehaviour
{
    public string[] sentences;
    public float typeSpeed = .02f;
    public bool dialogRunning;

    int index;
    TextMeshProUGUI textDisplay;
    bool continuable;
    float playerSpeedTemp;

    void Start()
    {
        if (GameObject.Find("Game manager").GetComponent<GameManager>().seenIntroduction && SceneManager.GetActiveScene().name == "Science floor")
        {
            gameObject.SetActive(false);
            return;
        }

        if (SceneManager.GetActiveScene().name == "Bad end" || SceneManager.GetActiveScene().name == "Good end")
        {
            GameObject.Find("Game manager").GetComponent<GameManager>().PauseTimers();
            textDisplay = GameObject.FindWithTag("CutsceneText").GetComponent<TextMeshProUGUI>();
            StartDialog();
            return;
        }

        // pause game
        GameObject.Find("Game manager").GetComponent<GameManager>().PauseTimers();
        playerSpeedTemp = GameObject.FindWithTag("Player").GetComponent<Player>().speed;
        GameObject.FindWithTag("Player").GetComponent<Player>().speed = 0;
        GameObject.FindWithTag("Player").transform.position = new Vector3(-11.13f, 12.25f, 0f);

        // show text
        GameObject.Find("Game manager").GetComponent<GameManager>().seenIntroduction = true;
        textDisplay = GameObject.FindWithTag("CutsceneText").GetComponent<TextMeshProUGUI>();
        textDisplay.text = "";
        StartDialog();
    }

    void Update()
    {
        if (textDisplay.text == sentences[index - 1])
        {
            continuable = true;
        }

        if (continuable && Input.anyKey)
        {
            PrintNewSentence();
        }
    }

    IEnumerator Type()
    {
        foreach (char symbol in sentences[index])
        {
            textDisplay.text += symbol;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void PrintNewSentence()
    {
        continuable = false;

        if (index < sentences.Length)
        {
            textDisplay.text = "";
            StartCoroutine(Type());
            index++;
        }
        else
        {
            EndDialog();
        }
    }

    void StartDialog()
    {
        dialogRunning = true;
        PrintNewSentence();
    }

    void EndDialog()
    {
        if (SceneManager.GetActiveScene().name != "Science floor")
        {
            Destroy(GameObject.Find("Game manager"));
            SceneManager.LoadScene("Menu");
            return;
        }

        textDisplay.text = "";
        dialogRunning = false;
        index = 0;
        gameObject.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<Player>().speed = playerSpeedTemp;
        GameObject.Find("Game manager").GetComponent<GameManager>().ResumeTimers();
    }
}
