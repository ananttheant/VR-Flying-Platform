using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{


    //movement target 
    //public Transform Target;

    //Speed of the platform
    public float Speed = 1;

    //array of destinations/targets
    public Transform[] targets;

    //Index for array
    private int NextIndex;

    //flag wheather we are moving or not
    private bool isMoving = false;

    // Use this for initialization
    void Start()
    {
        // set player's initial position to first target in the array
        transform.position = targets[0].position;

        //next index
        NextIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {

        //check for the input
        HandleInput();

        if (isMoving)
        {
            //movement of the platform
            HandleMovement();
        }

    }

    private void HandleInput()
    {
        //check for Fire1 Axis
        if (Input.GetButtonDown("Fire1"))
        {
            //negate
            isMoving = !isMoving;
        }

    }

    //take care of the movement of the platform
    void HandleMovement()
    {
        //calculate the distace from the target
        float distance = Vector3.Distance(transform.position, targets[NextIndex].position);

        //have we arrived yet?
        if (distance > 0)
        {
            //if no, calculate how much to move(step) d= v*t
            float step = Speed * Time.deltaTime;

            //move by that step
            transform.position = Vector3.MoveTowards(transform.position, targets[NextIndex].position, step);
        }
        else // if we have arrived
        {
            
            NextIndex++;

            if (NextIndex == targets.Length)
            {
                NextIndex = 0;
            }

                isMoving = false;
        }
    }
}
       
