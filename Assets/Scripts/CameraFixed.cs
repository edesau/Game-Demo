using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixed : MonoBehaviour {
    public Transform player;

    private float camMax;
    private float camMin;

	// Use this for initialization
	void Start () {
        camMax = 2.5f;
        camMin = -2.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.position.z < camMax && player.position.z > camMin)
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
    }
}
