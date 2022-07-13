using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAlert : MonoBehaviour
{
    public Button button;

    public int cantidadAdicional;

    public Button botonCerrar;

    private NewConstruction constructionRef;

    public Button confirmButton;

    public Text nombreObraAlerta;

    private float tiempoAlertas;

    private const float duracionAlerta = 12f;

    public ProgressBar barraAlerta;

    private GameManager comprobarFinal;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.parent.GetComponent<CameraController>().enabled = false;

        confirmButton.interactable = false;

        ColorBlock colors = confirmButton.colors;
        colors.disabledColor = Color.gray;

        confirmButton.colors = colors;

        comprobarFinal = Transform.FindObjectOfType<GameManager>().GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        tiempoAlertas += Time.deltaTime;

        if (tiempoAlertas >= duracionAlerta)
        {
            GameManager.contadorAlertas++;
            tiempoAlertas = 0;

            resetValues();

            comprobarFinal.PenaltiesProgress();
        }

        else
        {
            barraAlerta.current = (int)tiempoAlertas;
        }
    }

    public void ButtonClick()
    {
        button.interactable = false;

        ColorBlock colors = button.colors;
        colors.disabledColor = Color.green;
        button.colors = colors;

        confirmButton.interactable = true;

        colors = confirmButton.colors;
        colors.disabledColor = Color.white;

        confirmButton.colors = colors;

        GameManager.dineroJugador -= cantidadAdicional;

        botonCerrar.interactable = false;
    }

    public void ButtonClickConfirm()
    {
        constructionRef.FixedAlert();

        GameManager.alertShowed = false;

        

        resetValues();
    }

    private void resetValues()
    {
        button.interactable = true;

        ColorBlock colors = button.colors;

        colors.disabledColor = Color.green;

        button.colors = colors;


        confirmButton.interactable = false;

        colors = confirmButton.colors;

        colors.disabledColor = Color.gray;

        confirmButton.colors = colors;

        botonCerrar.interactable = true;
    }

    public void SetConstruction(NewConstruction newConstruction)
    {
        this.constructionRef = newConstruction;

        nombreObraAlerta.text = this.constructionRef.nombreObra;
    }
}
