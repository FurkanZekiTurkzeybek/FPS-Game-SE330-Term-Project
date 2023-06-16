using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerStats>()) {
            if (other.gameObject.GetComponent<PlayerStats>().getReadyForLevelTwo()) {
                SceneManager.LoadScene("LevelTwo");
            }
            else {
                Debug.Log("You are not yet ready for the second level.");
            }
        }
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}