using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI text;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = float.Parse(text.text);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        text.text = time.ToString("0");

        if (time < 0)
        {
            Application.Quit();
        }
    }
}
