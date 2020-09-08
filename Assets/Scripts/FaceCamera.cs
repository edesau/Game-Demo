using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {
    void Update() {
        // face the canvas towards the player
        Camera camera = Camera.main;
        transform.LookAt(camera.transform.position + Vector3.forward);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
