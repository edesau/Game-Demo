using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    public string sceneName;

    // Assumes that the name is correct
    void OnTriggerEnter(Collider other) {
        if (sceneName != null && sceneName.Length != 0)
            SceneManager.LoadScene("Scenes/" + sceneName);
    }
}