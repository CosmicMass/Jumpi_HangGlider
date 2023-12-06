using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime;
    float Timeremaining;
    public int startMinutes;

    public Image timerImage;
        
    void Start()
    {
        currentTime = startMinutes * 60;
        Timeremaining = currentTime;
    }

    void Update()
    {
        //currentTime = currentTime - Time.deltaTime;

        if (Timeremaining > 0)
        {
            Timeremaining -= Time.deltaTime;
            float fillval = Timeremaining / currentTime;
            timerImage.fillAmount = fillval;
        }

        if(Timeremaining <= 0)
        {
            Debug.Log("1 yıldız");
        }

        if(Timeremaining < 60 && Timeremaining > 0)
        {
            Debug.Log("2 Yıldız");
        }
        if(Timeremaining > 60 && Timeremaining < 120)
        {
            Debug.Log("3 yıldız");
        }
    }

}
