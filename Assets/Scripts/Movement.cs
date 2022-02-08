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
    private Gyroscope gyro;
    private Vector3 move;
    private Vector3 tilt;
    private void Start()
    {
        Input.gyro.enabled = true;
    }

    public void Move(Vector3 horizontalInput, Vector3 verticalInput)
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            move = (horizontalInput + verticalInput).normalized * playerSpeed;
            rb.AddForce(move);
        }
        else
        {
            // TODO: depending on start position https://stackoverflow.com/questions/29898900/unity-gyroscope-default-position
            Vector3 movement = Vector3.zero;
            movement = new Vector3(Input.acceleration.y + 0.75f, 0.0f,
                -Input.acceleration
                    .x);
            rb.AddForce(movement * playerSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectables"))
        {
            ScoreManager.instance.AddScore(collectableValue);
            //Debug.Log("Score");
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Collectable");
        }
        //Debug.Log("Score 11");
    }
}