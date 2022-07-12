using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuy : MonoBehaviour
{
    public Button otherButton;

    public enum ButtonType { cemento, metal, pintura, herramientas, lineasVida, senyales, epps, calidad, generador, elevador, grua, manoObra };

    public ButtonType buttonType;

    public int costeBoton;

    public bool caro;

    public NewConstruction constructionRef;

    private float porcentajeAlerta = 1f; //aumenta o disminuye 1

    private Button button;

   

    

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonClick()
    {
        ButtonStyle();

        Pay();

        ChangePercentatge();

        constructionRef.ActiveButtonAccept();

    }

    private void ChangePercentatge()
    {
        float alertaTotal = constructionRef.GetAlertPercentatge();

        if (caro)
        {
            alertaTotal -= porcentajeAlerta;
        }

        else 
        { 
            alertaTotal += porcentajeAlerta; 
        }

        constructionRef.SetAlerPercentatge(alertaTotal);
    }

    private void Pay()
    {
        GameManager.dineroJugador -= costeBoton;   
    }

    public void ButtonStyle() 
    {
        button.interactable = false;

        otherButton.interactable = false;

        ColorBlock colors = button.colors;
        colors.disabledColor = Color.green;
        button.colors = colors;

        colors.disabledColor = Color.gray;
        otherButton.colors = colors;
    }
}
