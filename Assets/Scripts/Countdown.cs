using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI text;

    float showTime;

    void Update()
    {
        showTime = Mathf.Ceil(GameObject.Find("Game manager").GetComponent<GameManager>().timeLeft / 60);
        text.text = showTime.ToString("0");

        if (showTime < 0)
        {
            Application.Quit();
        }
    }
}
