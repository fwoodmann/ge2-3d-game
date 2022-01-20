using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

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
