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

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.parent.GetComponent<CameraController>().enabled = false;

        confirmButton.interactable = false;

        ColorBlock colors = confirmButton.colors;
        colors.disabledColor = Color.gray;

        confirmButton.colors = colors;

    }

    // Update is called once per frame
    void Update()
    {
        
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
