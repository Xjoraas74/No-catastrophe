using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Health : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image oxBar;
    public Image liveBar;
    public float curHealth = 0;
    private float liveFill;
    private float oxFill;
    float time;
    public int amountDH; // количесво ударов от многоножки
    private int healthAmount = 1000;
     
    void Start()
    {
        oxFill = 1f;
        liveFill = 1f;
        time = 30;
        amountDH = 0;
    }

     
    void Update()
    {
        if (oxFill > 0)
        {
            oxFill -= Time.deltaTime / 30;
            time -= Time.deltaTime;
            text.text = time.ToString("0");

            oxBar.fillAmount = oxFill;
        }
        if (oxBar.fillAmount == 0)
        {
            liveFill -= Time.deltaTime / 20;
            liveBar.fillAmount = liveFill;
        }
        
        if (amountDH != 0)
        {
            DamageHeal(amountDH);
            SetHealth(GetHealthNormalized());
            amountDH = 0;
        }   
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackHitBox")
        {
            amountDH -= 1;
            curHealth++;
        }
    }

    private void DamageHeal(int amount)
    {
        healthAmount += amount;
        if (healthAmount < 0)
        {
            healthAmount = 0;
        }
        if (healthAmount > 1000)
        {
            healthAmount = 1000;
        }
    }

    private float GetHealthNormalized()
    {
        return (float)healthAmount / 1000;
    }

    private void SetHealth (float healthNormalized)
    {
        liveBar.fillAmount = healthNormalized;
    }
}
