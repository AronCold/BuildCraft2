using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject panelGanar;

    public GameObject panelPerderBancarrota;

    public GameObject panelPerderPenalizaciones;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void GanarJuego()
    {
        panelGanar.SetActive(true);
    }

    public void PerderJuegoBancarrota()
    {
        panelPerderBancarrota.SetActive(true);
    }

    public void PerderJuegoPenalizaciones()
    {
        panelPerderPenalizaciones.SetActive(true);
    }
   
}
