using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewConstruction : MonoBehaviour
{
    public ProgressBar progressBar;

    public bool constructionComplete = false;

    public bool alerted = false;

    private float timeProgress;

    private bool constructionAccepted;

    private int ordenDeObra;

    private float alertPercentatge=12;

    public List<ProgressBar> visualConstructions = new List<ProgressBar>();

    public List<Text> textosObras = new List<Text>();


    public int valorProyecto;

    public int presupuestoGasto;

    public int cuotas;

    public int duracionProyecto; //NO CAMBIAR POR CODIGO. SE CAMBIA EN EL INSPECTOR DE UNITY

    private int tiempoHastaCuota;

    private int tiempoAux;

    public int variableConstruccion;

    private int tiempoError;

    private int tiempoErrorAux;

    public List<GameObject> panelesAlerta;

    private bool isShowingAlertPanel;

    public List<Button> botones;

    public GameObject buttonAccept;

    public string nombreObra;

    private GameManager gameManager;

    public GameObject ButtonAlert;

    //public GameObject modeloAMedias;

    public GameObject modeloConstruccionAcabada;

    //public GameObject objetoSeleccion;

    public Selected seleccion;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = Transform.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        constructionAccepted = false;
        GameManager.constructions.Add(this);

        tiempoHastaCuota = 0;

        tiempoAux = duracionProyecto / (cuotas - 1);

        progressBar.maximum = duracionProyecto;

        modeloConstruccionAcabada.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (constructionAccepted&&alerted==false&&GameManager.alertShowed==false)
        {
            if (progressBar.current < progressBar.maximum)
            {
                timeProgress += Time.deltaTime / 3;

                progressBar.current = (int)timeProgress;

                visualConstructions[ordenDeObra-1].current= (int)timeProgress;

                if(progressBar.current == tiempoHastaCuota)
                {
                    SumarCuotasAlPresupuesto();
                }
            }

            else
            {
                if (constructionComplete == false)
                {
                    constructionComplete = true;

                    modeloConstruccionAcabada.SetActive(true);

                    seleccion.objeto.SetActive(false);

                    GameManager.contadorConstruccionesAcabadas++;

                    //Activar elementos visuales 

                    gameManager.AllConstructionsFinished();
                }        
            }
        }

        else if (constructionAccepted && alerted == true) //////////////////////////
        {
            showAlert();

        }

        if (progressBar.current == tiempoError && !alerted) 
        {
            setAlert();
        }
    }

    private void showAlert()
    {
        
        if(!isShowingAlertPanel)
        {
            int PosicionAlerta = Random.Range(0, panelesAlerta.Count - 1);
            panelesAlerta[PosicionAlerta].SetActive(true);
            isShowingAlertPanel = true;

            Camera.main.transform.parent.GetComponent<CameraController>().enabled = false;

            panelesAlerta[PosicionAlerta].GetComponent<ButtonAlert>().SetConstruction(this);

            GameManager.alertShowed = true;

        }

       
    }

    private void setAlert()
    {

        if (tiempoError <= duracionProyecto)
        {
            alerted = true;
            
            tiempoError += tiempoErrorAux;

            ButtonAlert.SetActive(true);
          
        }

        else
        {
            tiempoError = duracionProyecto;
        }

    }

    public void FixedAlert()
    {
        alerted = false;

        isShowingAlertPanel = false;

        ButtonAlert.SetActive(false);

        foreach(GameObject panel in panelesAlerta)
        {
            panel.SetActive(false);

            
        }

        Camera.main.transform.parent.GetComponent<CameraController>().enabled = true;
    }

    public void SumarCuotasAlPresupuesto()
    {
        if (tiempoHastaCuota <= duracionProyecto)
        {
            GameManager.dineroJugador += valorProyecto / cuotas;

            tiempoHastaCuota += tiempoAux;
        }

        else
        {
            tiempoHastaCuota = duracionProyecto;
        }
    }

    public void AcceptedConstruction()
    {
        constructionAccepted = true;

        ordenDeObra = GameManager.ordenDeObras + 1;

        visualConstructions[ordenDeObra - 1].maximum = duracionProyecto;

        textosObras[ordenDeObra - 1].text = nombreObra;

        

        GameManager.ordenDeObras = ordenDeObra;

        SumarCuotasAlPresupuesto();

        RandomAlert();

        Camera.main.transform.parent.GetComponent<CameraController>().enabled = true;

    }

    public void RandomAlert()
    {   
        if (alertPercentatge == 0)
        {
            tiempoError = Random.Range(50, duracionProyecto - 10);
        }
        //alerted;
        else
        {
            tiempoError = (int)(duracionProyecto / alertPercentatge) * variableConstruccion;
        }

        tiempoErrorAux = tiempoError;
    }

    public float GetAlertPercentatge()
    {
        return alertPercentatge;
    }

    public void SetAlerPercentatge(float alertPercentatge)
    {
        this.alertPercentatge = alertPercentatge;
    }



    public void ActiveButtonAccept()
    {
        bool esActivado = false;

        foreach(Button boton in botones)
        {
            if (boton.interactable == false)
            {
                esActivado = true;
            }

            else
            {
                esActivado = false;
                break;
            }
        }

        buttonAccept.SetActive(esActivado);
    }
}
