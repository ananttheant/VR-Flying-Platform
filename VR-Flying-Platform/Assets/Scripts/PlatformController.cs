using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {


    //movement target 
    public Transform Target;

    //Speed of the platform
    public float Speed = 1;

    //flag wheather we are moving or not
    private bool isMoving = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

        //check for the input HMD
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
        float distance = Vector3.Distance(transform.position, Target.position);

        //have we arrived yet?
        if (distance > 0)
        {
            //if no, calculate how much to move(step) d= v*t
            float step = Speed * Time.deltaTime;

            //move by that step
            transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
        }
    }
}
