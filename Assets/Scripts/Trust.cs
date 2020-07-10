using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trust : MonoBehaviour
{
    public Image bar1;
    public Image bar2;
    public Image bar3;
    public Image bar4;
    public Image bar5;
    public int trustglobal1 = 0;
    public int trustglobal2 = 0;
    public int trustglobal3 = 0;
    public int trustglobal4 = 0;
    public int trustglobal5 = 0;
    public int trustchenge = 0;
    public int who = 1;

    void Start()
    {
        bar1.fillAmount = (float)trustglobal1 / 100;
        bar2.fillAmount = (float)trustglobal2 / 100;
        bar3.fillAmount = (float)trustglobal3 / 100;
        bar4.fillAmount = (float)trustglobal4 / 100;
        bar5.fillAmount = (float)trustglobal5 / 100;
    }

    void Update()
    {
        if (trustchenge != 0)
        {
            Changing(trustchenge);
            SetTrust(GetTrusthNormalized());
            trustchenge = 0;
        }
    }

    private void Changing(int amount)
    {
        if (who == 1)
        {
            trustglobal1 += amount;
            if (trustglobal1 < 0)
            {
                trustglobal1 = 0;
            }
            if (trustglobal1 > 100)
            {
                trustglobal1 = 100;
            }
        }
        else if (who == 2)
        {
            trustglobal2 += amount;
            if (trustglobal2 < 0)
            {
                trustglobal2 = 0;
            }
            if (trustglobal2 > 100)
            {
                trustglobal2 = 100;
            }
        }
        else if (who == 3)
        {
            trustglobal3 += amount;
            if (trustglobal3 < 0)
            {
                trustglobal3 = 0;
            }
            if (trustglobal3 > 100)
            {
                trustglobal3 = 100;
            }
        }
        else if (who == 4)
        {
            trustglobal4 += amount;
            if (trustglobal4 < 0)
            {
                trustglobal4 = 0;
            }
            if (trustglobal4 > 100)
            {
                trustglobal4 = 100;
            }
        }
        else if (who == 5)
        {
            trustglobal5 += amount;
            if (trustglobal5 < 0)
            {
                trustglobal5 = 0;
            }
            if (trustglobal5 > 100)
            {
                trustglobal5 = 100;
            }
        }
    }

    private float GetTrusthNormalized()
    {
        if (who == 1)
        {
            return (float)trustglobal1 / 100;
        }
        if (who == 2)
        {
            return (float)trustglobal2 / 100;
        }
        if (who == 3)
        {
            return (float)trustglobal3 / 100;
        }
        if (who == 4)
        {
            return (float)trustglobal4 / 100;
        }
        if (who == 5)
        {
            return (float)trustglobal5 / 100;
        }
        return (float)trustglobal1 / 100;
    }

    private void SetTrust(float Normalized)
    {
        if (who == 1)
        {
            bar1.fillAmount = Normalized;
        }
        if (who == 2)
        {
            bar2.fillAmount = Normalized;
        }
        if (who == 3)
        {
            bar3.fillAmount = Normalized;
        }
        if (who == 4)
        {
            bar4.fillAmount = Normalized;
        }
        if (who == 5)
        {
            bar5.fillAmount = Normalized;
        }
    }

    public void ChangeTrust(int amound)
    {
        // Тут же изменить значение who на номер полоски, чтоб знать, к чему прибавить
        trustchenge += amound;
    }

}
