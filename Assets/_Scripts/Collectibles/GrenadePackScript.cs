using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePackScript : CollectibleScript {
    void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        if (other.gameObject.GetComponent<PlayerStats>()) {
            other.gameObject.GetComponentInChildren<PlayerStats>().addGrenade(2);
        }
    }

    // Start is called before the first frame update
    void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() { }
}