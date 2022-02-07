using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject platform;

    public float rotationSpeed = 50f;    //set Rotation Speed
    public string rotationAxis;         //set the rotation axis

    /*public string moveAxis;
    public float moveSpeed;
    Vector3 pointB = new Vector3 (0, 0.5f, 0);
    Vector3 pointA = new Vector3(0, 0, 0);
    Vector3 startPosition;
    void Start()
    {
        startPosition = platform.transform.position;
    }*/

    // Update is called once per frame
    void Update()
    {
        switch (rotationAxis) 
        {
            case "X":
                transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
                break;
            
            case "Y":
                transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
                break;

            case "Z":
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                break;
            
            default:
                break;
        }

      /*  switch (moveAxis)
        {
            case "Y":
                // Debug.Log(currentPosition);
                Vector3 movePositionA = startPosition + pointA;
                Vector3 movePositionB = startPosition + pointB;

                transform.position = transform.position + movePositionA;
                break;

            default:
                break;
        } */

    }

}
