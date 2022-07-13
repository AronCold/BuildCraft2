using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool alertShowed;

    public static float dineroJugador;

    public Text dineroJugadorTexto;

    public static int dia;

    public Text diaTexto;

    public static int mes;

    public Text mesTexto;

    public static int año;

    public Text añoTexto;

    public static float hora;

    public Text horaTexto;

    public static List<NewConstruction> constructions = new List<NewConstruction>();

    public static int ordenDeObras = 0;

    public static bool isFinished = false;

    public static int contadorAlertas;

    public ProgressBar penaltyProgress;

    public static int contadorConstruccionesAcabadas = 0;

    public ProgressBar constructionProgress;

    private FinishGame finalJuego;

    // Start is called before the first frame update
    void Start()
    {
        alertShowed = false;

        dineroJugador = 200000;

        dineroJugadorTexto.text = dineroJugador.ToString();

        dia = 1;

        diaTexto.text = dia.ToString();

        mes = 1;

        mesTexto.text = mes.ToString();

        año = 2022;

        añoTexto.text = año.ToString();

        hora = 0;

        horaTexto.text = hora.ToString();

        finalJuego = Transform.FindObjectOfType<FinishGame>().GetComponent<FinishGame>();

        //constructionProgress.current = 0;

    }

    // Update is called once per frame
    void Update()
    {
        dineroJugadorTexto.text = dineroJugador.ToString();

        diaTexto.text = dia.ToString();

        mesTexto.text = mes.ToString();

        añoTexto.text = año.ToString();

        horaTexto.text = hora.ToString();

        constructionProgress.current = contadorConstruccionesAcabadas;

    }

    public void AllConstructionsFinished()
    {
        foreach (NewConstruction construction in constructions)
        {
            if (construction.constructionComplete)
            {
                isFinished = true;

                Debug.Log("Si cuenta la obra finalizada");

            }

            else
            {
                isFinished = false;
                break;
            }

        }

        if (isFinished == true && contadorConstruccionesAcabadas >= 4)
        {
            //JUEGO COMPLETADO
            Debug.Log("JUEGO COMPLETADO JESUUUUUUUS");

            finalJuego.GanarJuego();
        }
    }

    public void PenaltiesProgress()
    {
        penaltyProgress.current = contadorAlertas;

        if (contadorAlertas >= 5)
        {
            Debug.Log("GAME OVER: PENALTIES");

            finalJuego.PerderJuegoPenalizaciones();
            
        }
    }
}
