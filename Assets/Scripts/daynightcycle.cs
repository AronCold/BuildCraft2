using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class daynightcycle : MonoBehaviour
{
    private float dayduration;


    private float hours;

    private float minutes;


    private int days;

    private int months;

    private int years;


    public GameObject lightFont;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {

        dayduration = 12.00f;

        currentTime = 0.00f;

        hours = 0;

        minutes = 0;

        days = 1;

        months = 1;

        years = 2022;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < 1.00f)
        {
            //hours = currentTime / 24;
            //Debug.Log(hours);
            //Debug.Log(currentTime*12);
            hours = currentTime * 24;
            minutes = currentTime * 1440;

            //Debug.Log(dayduration);
            lightFont.transform.localRotation = Quaternion.Euler((currentTime * 360f) - 90, 170, 0);

            currentTime += (Time.deltaTime / dayduration);

        }

        else
        { //Cuando pasa esto es porque ha pasado un dia.
            currentTime = 0;
            days++;

            if (days > 30)
            {
                months++;
                days = 1;
            }
            if (months > 12)
            {
                years++;
                months = 1;
            }

            
            GameManager.dia = days;
            GameManager.mes = months;
            GameManager.año = years;
            Debug.Log(days);
        }

        GameManager.hora = (float)Math.Floor(hours);
    }
}
