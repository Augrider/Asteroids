using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chargesCount;
    [SerializeField] private TextMeshProUGUI timeForFullRechargeText;

    [SerializeField] private Slider[] sliderBars;


    public void UpdateDisplay(float charge, int maxCharges, float oneChargeCooldown)
    {
        var timeForFullRecharge = (maxCharges - charge) * oneChargeCooldown;
        var charges = Mathf.FloorToInt(charge);

        chargesCount.SetText(charges.ToString());
        timeForFullRechargeText?.SetText(timeForFullRecharge.ToString("F2") + " s");

        FillBars(charge);
    }



    private void FillBars(float value)
    {
        var valueInt = Mathf.FloorToInt(value);

        for (int i = 0; i < sliderBars.Length; i++)
        {
            if (i < valueInt)
                sliderBars[i].SetValueWithoutNotify(1);

            if (i > valueInt)
                sliderBars[i].SetValueWithoutNotify(0);

            sliderBars[i].SetValueWithoutNotify(value - i);
        }
    }
}