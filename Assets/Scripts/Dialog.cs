using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typeSpeed = .02f;
    public GameObject continueButton;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = "";
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
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

    public void TypeNewSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
}
