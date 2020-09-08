using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://unity3d.com/learn/tutorials/projects/roll-ball-tutorial/moving-player?playlist=17141

public class JitterMove : MonoBehaviour {
    public float speed;

    private Rigidbody rb;
    private bool canJump;

    void Start() {
        rb = GetComponent<Rigidbody>();
        canJump = true;
    }

    void FixedUpdate() {
        // Space = Jump
        if (canJump && Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
            canJump = false;
        }

        // Read input (WASD, arrow keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // When keys are not pressed, stop movement
        if (moveHorizontal == 0 && moveVertical == 0)
            rb.angularVelocity = Vector3.zero;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // https://www.reddit.com/r/Unity3D/comments/3j8x8a/moving_ball_relative_to_camera_direction/
        Vector3 relativeMovement = Camera.main.transform.TransformVector(movement);

        rb.AddForce(relativeMovement * speed);
    }

    // When the ground is touched, allow jumping again
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("ground"))
            canJump = true;
    }

    // When the ground is left, disallow jumping
    private void OnCollisionExit(Collision collision) {
        if (collision.collider.CompareTag("ground"))
            canJump = false;
    }
}
