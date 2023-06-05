using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitScript : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerStats>()) {
            Destroy(gameObject);
            other.gameObject.GetComponent<PlayerStats>().increaseHealth(10);
        }
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}