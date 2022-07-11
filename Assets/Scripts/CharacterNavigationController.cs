using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavigationController : MonoBehaviour
{
    public bool reachedDestination = false;

    private float movementSpeed = 2.0f;
    private float rotationSpeed = 120f;
    private float stopDistance = 0.40f;

    Vector3 lastPosition;
    Vector3 velocity;
    Vector3 destination;

    public int actualNode = 0;

    public Transform[] waypoints;

    private Vector3 inicialPosition;


    // Start is called before the first frame update
    void Start()
    {
        inicialPosition = transform.position;

        if (waypoints.Length > 0)
        {
            destination = waypoints[actualNode].transform.position;
        }

        else
        {
            reachedDestination = true;
        }

        //Debug.Log(destination);
        //Debug.Log(waypoints.Length);
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(destination);
        if (reachedDestination) return ;//gameObject.destroy();
        if(transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;
            if(destinationDistance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed*3 * Time.deltaTime);
            }

            else
            {
                actualNode++;
                if (actualNode < waypoints.Length)
                {
                    destination = waypoints[actualNode].transform.position;
                    
                }
                else
                {
                    
                    //reachedDestination = true;

                    transform.position = inicialPosition;

                    actualNode = 0;

                    destination = waypoints[actualNode].transform.position;
                }
               
            }

            velocity = (transform.position - lastPosition) / Time.deltaTime;
            var velocityMagnitude = velocity.magnitude;
            velocity = velocity.normalized;
            var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
            var rightDotProduct = Vector3.Dot(transform.right, velocity);
        }

        else
        {
            reachedDestination = true;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        reachedDestination = false;
    }

}
