using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangePositionMap : MonoBehaviour
{
    private Camera cameraMinimap;

    private CameraController mainCameraController;

    // Start is called before the first frame update
    void Start()
    {
        cameraMinimap = GetComponent<Camera>();
        mainCameraController = Camera.main.GetComponentInParent<CameraController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cameraMinimap.pixelRect.Contains(Input.mousePosition));
        
        if (Input.GetMouseButtonDown(0)){

            
            RaycastHit hit;
            Ray ray = cameraMinimap.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                mainCameraController.newPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }

            /*Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;

            }*/
        }
    }

    bool isMouseOverMinimap()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
