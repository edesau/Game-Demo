using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    public Transform door;

    private float maxY;
    private float minY;

    public bool playerNearby;

	// Use this for initialization
	void Start () {
        maxY = 2.65f;
        minY = 1.0f;

        playerNearby = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerNearby) {
            if (door.position.y < maxY)
                door.position = AddY(door.position, 0.05f);
        } else {
            if (door.position.y > minY)
                door.position = AddY(door.position, -0.05f);
        }
	}

    private Vector3 AddY(Vector3 v, float f) {
        return new Vector3(v.x, v.y + f, v.z);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }
}
