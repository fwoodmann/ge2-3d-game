using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject platform;

    public float rotationSpeed = 50;    //set Rotation Speed
    public string rotationAxis;         //set the rotation axis

    public string moveAxis;
    public float moveSpeed = 1;
    Vector3 pointB = new Vector3 (0, -5, 0);
    Vector3 pointA = new Vector3(0, 0, 0);

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

        switch (moveAxis)
        {
            case "Y":
                moveObstacle();
                break;

            default:
                break;
        } 

    }

    void moveObstacle()
    {
        Vector3 currentPosition = platform.transform.position;
        Debug.Log(currentPosition);
        Vector3 movePositionA = currentPosition + pointA;
        Vector3 movePositionB = currentPosition + pointB;

        transform.position = Vector3.Lerp(movePositionA, movePositionB, moveSpeed * Time.deltaTime);
    }


}
