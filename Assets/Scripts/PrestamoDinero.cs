using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestamoDinero : MonoBehaviour
{
    public float dineroPrestamo;

    public float interes;

    public float dineroDevuelto;

    public float timeLeft;

    public const float lapseTime = 30;

    public bool haAceptadoPrestamo;

    // Start is called before the first frame update
    public void Start()
    { 
        dineroPrestamo=300000;

        interes = 0.1f;

        dineroDevuelto = 0;

        timeLeft = lapseTime;
        haAceptadoPrestamo = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if(dineroDevuelto<dineroPrestamo && haAceptadoPrestamo)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0.00f)
            {
                timerEnded();
            }
        }
    }

    private void timerEnded()
    {
        GameManager.dineroJugador -= (dineroPrestamo + (dineroPrestamo * interes)) / 10;
        Debug.Log(GameManager.dineroJugador);

        dineroDevuelto += dineroPrestamo / 10;

        timeLeft = lapseTime;
    }

    public void AceptarPrestamo()
    {
        haAceptadoPrestamo = true;


        GameManager.dineroJugador += dineroPrestamo;
        Debug.Log(GameManager.dineroJugador);
    }
}
