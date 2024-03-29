using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RocketPackScript : CollectibleScript {
    void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        if (other.gameObject.GetComponent<PlayerStats>()) {
            other.gameObject.GetComponentInChildren<PlayerStats>().addRocket(3);
        }
    }

    // Start is called before the first frame update
    void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() { }
}