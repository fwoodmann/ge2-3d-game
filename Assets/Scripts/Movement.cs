using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Movement: MonoBehaviour {
    // This could be used to move the Stage instead of the Player
    // https://answers.unity.com/questions/1805201/how-can-i-pitch-and-roll-a-circular-platform-witho.html

    [SerializeField] Rigidbody rb;

    [SerializeField] private int collectableValue = 0;
    [HideInInspector] public float playerSpeed;
    public bool gyroEnabled;
    private Gyroscope gyro;
    private Vector3 move;
    private Vector3 tilt;
    
    private void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        return true;
    }


    public void Move(Vector3 horizontalInput, Vector3 verticalInput)
    {
        if(SystemInfo.deviceType == DeviceType.Desktop)
        {
            move = (horizontalInput + verticalInput).normalized * playerSpeed;
        }
        else
        {
            tilt.z = Input.acceleration.y;
            tilt.x = Input.acceleration.x;
            rb.AddForce(tilt*playerSpeed*Time.deltaTime);
        }
        // Debug.Log(move);
       rb.AddForce(move);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectables"))
        {
            ScoreManager.instance.AddScore(collectableValue);
            //Debug.Log("Score");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Enemies")){
            SceneManager.LoadScene(2);  //return to menu after player dies
        }
        //Debug.Log("Score 11");
    }
}