using UnityEngine;
using TMPro;
using System.Collections;

public class Click : MonoBehaviour
{
    public string[] comment;
    public int personNumber;
    public float typeSpeed = .02f;

    bool lockTyping;

    void OnMouseDown()
    {
        bool found = false;
        foreach (string com in GameObject.Find("Game manager").GetComponent<GameManager>().commentsFound)
        {
            if (com == comment[0])
            {
                found = true;
            }
        }

        if (!found)
        {
            GameObject.FindWithTag("Player").GetComponent<Trust>().who = personNumber + 1;
            int amount = 0;
            switch (personNumber)
            {
                case 0:
                    amount = 1;
                    break;
                case 4:
                    amount = 2;
                    break;
                default:
                    amount = 3;
                    break;
            }
            GameObject.FindWithTag("Player").GetComponent<Trust>().ChangeTrust(100 / amount);
            GameObject.Find("Game manager").GetComponent<GameManager>().commentsFound.Add(comment[0]);
        }

        if (!lockTyping)
        {
            TypeComment();
        }
    }

    void TypeComment()
    {
        lockTyping = true;
        GameObject.FindWithTag("Text").GetComponent<TextMeshProUGUI>().text = "";
        StartCoroutine(Type());
        lockTyping = false;
    }

    IEnumerator Type()
    {
        foreach (char symbol in comment[0])
        {
            GameObject.FindWithTag("Text").GetComponent<TextMeshProUGUI>().text += symbol;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void Update()
    {
        if (GameObject.FindWithTag("Text").GetComponent<TextMeshProUGUI>().text == comment[0])
        {
            Invoke("ClearText", 2f);
        }
    }

    void ClearText()
    {
        GameObject.FindWithTag("Text").GetComponent<TextMeshProUGUI>().text = "";
    }
}
