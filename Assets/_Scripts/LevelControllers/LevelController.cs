using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerStats>()) {
            if (other.gameObject.GetComponent<PlayerStats>().getReadyForLevelTwo()) {
                other.gameObject.GetComponent<PlayerStats>().changeLevels();

                SceneManager.LoadScene("LevelTwo");
            }
        }
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}