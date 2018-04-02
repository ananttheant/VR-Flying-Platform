using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To test the game, cant always setup VR headset, so you can use mouse, click and drag to move the camera angle
namespace MyTools
{

    

    public class DragCamera : MonoBehaviour
    {
        //only want this to work in editor not in the build 
        #if UNITY_EDITOR
        
        //flag to check dragging
        bool isDragging = false;

        //starting point of the camera movement
        private float StartMouseX;

        private float StartMouseY;

        //camera component to get a hold of the camera and do the changes to the camera rotation
        private Camera cam;

        // Use this for initialization
        void Start()
        {
            cam = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            //if we press the right mouse button and we haven't started dragging

            if (Input.GetMouseButtonDown(1) && !isDragging)
            {
                //set flag to true
                isDragging = true;

                //save the mouse starting position
                StartMouseX = Input.mousePosition.x;
                StartMouseY = Input.mousePosition.y;

            }
            //if we are not pressing, and we were dragging
            if (Input.GetMouseButtonUp(1) && isDragging)
            {
                //set the flag to false
                isDragging = false;
            }

        }

        void LateUpdate()
        {
            //if we are dragging
            if (isDragging)
            {
                //calculate the current position of the mouse
                float EndMouseX = Input.mousePosition.x;
                float EndMouseY = Input.mousePosition.y;

                //difference (in screen coordinates)
                float DiffX = EndMouseX - StartMouseX;
                float DiffY = EndMouseY - StartMouseY;
                if (DiffX == 0 && DiffY == 0) return;

                //New center of the screen
                float newCenterX = Screen.width / 2 + DiffX;
                float newCenterY = Screen.height / 2 + DiffY;

                //get the world coordinates, where we should be looking at 
                Vector3 LookAtPoint = cam.ScreenToWorldPoint(new Vector3(newCenterX, newCenterY, cam.nearClipPlane));

                // make camera look at the new position
                transform.LookAt(LookAtPoint);

                //update start position for the next call
                StartMouseX = EndMouseX;
                StartMouseY = EndMouseY;
            }
        }

        #endif
    }
}



