using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionBar : MonoBehaviour
{

    public float maxValue = 100;
    public Color color = Color.red;
    public int width = 4;
    public Slider Alice;
    public bool isRight;

    private static float current;

    void Start()
    {
        Alice.fillRect.GetComponent<Image>().color = color;

        Alice.maxValue = maxValue;
        Alice.minValue = 0;
        current = maxValue;

        UpdateUI();
    }

    public static float currentValue
    {
        get { return current; }
    }

    void Update()
    {
        if (current < 0) current = 0;
        if (current > maxValue) current = maxValue;
        Alice.value = current;
    }

    void UpdateUI()
    {
        RectTransform rect = Alice.GetComponent<RectTransform>();

        int rectDeltaX = Screen.width / width;
        float rectPosX = 0;

        if (isRight)
        {
            rectPosX = rect.position.x - (rectDeltaX - rect.sizeDelta.x) / 2;
            Alice.direction = Slider.Direction.RightToLeft;
        }
        else
        {
            rectPosX = rect.position.x + (rectDeltaX - rect.sizeDelta.x) / 2;
            Alice.direction = Slider.Direction.LeftToRight;
        }

        rect.sizeDelta = new Vector2(rectDeltaX, rect.sizeDelta.y);
        rect.position = new Vector3(rectPosX, rect.position.y, rect.position.z);
    }

    public static void AdjustCurrentValue(float adjust)
    {
        current += adjust;
    }
}