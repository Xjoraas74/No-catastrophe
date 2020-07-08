using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI text;

    float realTime;
    float showTime;

    // Start is called before the first frame update
    void Start()
    {
        realTime = float.Parse(text.text);
    }

    // Update is called once per frame
    void Update()
    {
        realTime -= Time.deltaTime;
        showTime = Mathf.Round(realTime / 60);
        text.text = showTime.ToString("0");

        if (realTime < 0)
        {
            Application.Quit();
        }
    }
}
