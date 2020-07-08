using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Health : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image oxBar;
    public float oxFill;
    int flag = 0;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        oxFill = 1f;
        time = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (oxFill >= 0)
        {
            oxFill -= Time.deltaTime / 30;
            time -= Time.deltaTime;
            text.text = time.ToString("0");

            oxBar.fillAmount = oxFill;
        }
    }
}
