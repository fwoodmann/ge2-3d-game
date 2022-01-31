using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*  
        Cinemachine used for CameraMovement 
        Third Person Camera > Orbits > Body > Y Damping for changes in Y responsiveness
        Rig Height and Radius can be changed, play around, so that it feels good

        !! CameraTilt on PlayerInput not Implemented yet!

        Force is added from the CameraPosition and Controller(workd well with the New Camera Movement)
    */
    public GameObject player;
    Vector3 horizontalInput, verticalInput;
    
    void Update()
    {
        horizontalInput = transform.right * Input.GetAxis("Horizontal");
        verticalInput = transform.forward * Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        player.GetComponent<Movement>().Move(horizontalInput,verticalInput);
    }

}
