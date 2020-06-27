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

    // Start is called before the first frame update
    void Start()
    {
        textDisplay = GameObject.FindWithTag("Text").GetComponent<TextMeshProUGUI>();
        continueButton = GameObject.FindWithTag("ContinueButton");
        textDisplay.text = "";
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index - 1])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char symbol in sentences[index].ToCharArray())
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
}
