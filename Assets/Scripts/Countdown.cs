using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float realTime;

    float showTime;

    void Start()
    {
        realTime = GameObject.Find("Game manager").GetComponent<GameManager>().timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        realTime -= Time.deltaTime;
        showTime = Mathf.Ceil(realTime / 60);
        text.text = showTime.ToString("0");

        if (realTime < 0)
        {
            Application.Quit();
        }
    }
}
