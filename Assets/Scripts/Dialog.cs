using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public string[] sentences;
    public float typeSpeed = .02f;
    public bool dialogRunning;
   
    int index;
    GameObject continueButton;
    TextMeshProUGUI textDisplay;

    void Start()
    {
        textDisplay = GameObject.FindWithTag("Text").GetComponent<TextMeshProUGUI>();
        continueButton = GameObject.FindWithTag("ContinueButton");
        textDisplay.text = "";
        continueButton.SetActive(false);
    }

    void Update()
    {
        if (textDisplay.text == sentences[index - 1])
        {
            continueButton.SetActive(true);
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
        continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        continueButton.GetComponent<Button>().onClick.AddListener(PrintNewSentence);
        continueButton.SetActive(false);

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

    public void StartDialog()
    {
        dialogRunning = true;
        PrintNewSentence();
    }

    public void EndDialog()
    {
        textDisplay.text = "";
        continueButton.SetActive(false);
        dialogRunning = false;
        index = 0;
    }

    public void TypeSentenceByNumber(int i)
    {
        textDisplay.text = "";
        int tmp = index;
        index = i;
        PrintNewSentence();
        index = tmp;
    }
}
