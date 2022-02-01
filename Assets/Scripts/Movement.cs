using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour {
    // This could be used to move the Stage instead of the Player
    // https://answers.unity.com/questions/1805201/how-can-i-pitch-and-roll-a-circular-platform-witho.html

    [SerializeField] Rigidbody rb;

    [HideInInspector] public float playerSpeed;

    public void Move(Vector3 horizontalInput, Vector3 verticalInput)
    {
        Vector3 move = (horizontalInput + verticalInput).normalized * playerSpeed;
        rb.AddForce(move);
    }

}