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
    public float playerSpeed;

    public void Move(Vector3 horizontalInput, Vector3 verticalInput)
    {
        Vector3 move = (horizontalInput + verticalInput).normalized * playerSpeed;
       // Debug.Log(move);
        rb.AddForce(move);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectables"))
        {
            //ScoreManager.instance.AddScore(collectableValue);
            Debug.Log("Score");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Enemies")){
            SceneManager.LoadScene(2);  //return to menu after player dies
        }
        Debug.Log("Score 11");
    }
}