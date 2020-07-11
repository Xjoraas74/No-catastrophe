using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image oxBar;
    public Image liveBar;
    private float oxFill = 1f;
    float time = 30;
    private int amountDH = 0;
    private int amountOX = 0;
    private int healthAmount = 10000;
    private int oxAmount = 30;

    void Update()
    {
        if (oxFill > 0)
        {
            oxFill -= Time.deltaTime / 30;
            time -= Time.deltaTime;
            if (time > 30)
            {
                time = 30;
                oxFill = 1f;
            }
            text.text = time.ToString("0");

            oxBar.fillAmount = oxFill;
        }
        if (oxBar.fillAmount == 0)
        {
            amountDH -= 2;
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
            amountDH -= 40;
        }
        if (collision.gameObject.name == "PlusLive1")
        {
            amountDH += 500;
        }
        if (collision.gameObject.name == "PlusOxigen1")
        {
            
            time += 3;
            oxFill += time / 30;

        }
        if (collision.gameObject.name == "PlusOxigen2")
        {
            time += 6;
            oxFill += time / 30;
        }
    }

    private void DamageHeal(int amount)
    {
        healthAmount += amount;
        if (healthAmount <= 0)
        {
            Death();
        }
        if (healthAmount > 10000)
        {
            healthAmount = 10000;
        }
    }

    private float GetHealthNormalized()
    {
        return (float)healthAmount / 10000;
    }

    private void SetHealth (float healthNormalized)
    {
        liveBar.fillAmount = healthNormalized;
    }


    void Death()
    {
        // GameObject.Find("Game manager").GetComponent<GameManager>().ReloadMonsters();
        SceneManager.LoadScene("Monsters");
    }
}
