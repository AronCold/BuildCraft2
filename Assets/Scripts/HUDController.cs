using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    public GameObject map;

    private Animator mapAnimator;

    private bool isMapActivated = false;

    private bool isRentButtonActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        //map.SetActive(false);

        mapAnimator = map.GetComponent<Animator>();
    }

    public void OnMapButtonClick()
    {

        if (isMapActivated)
        {
            mapAnimator.SetTrigger("Deactivate");
            isMapActivated = false;

        }
        //map.SetActive(!map.activeInHierarchy);
        else
        {
            mapAnimator.SetTrigger("Activate");
            isMapActivated = true;
        }
    }

    public void OnRentButtonClick()
    {
        //El salto de la ventana emergente ya lo hace el UI de Unity, no hace falta incluir nada aquí
    }
}
