using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitScript : CollectibleScript {
    void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        if (other.gameObject.GetComponent<PlayerStats>()) {
            other.gameObject.GetComponent<PlayerStats>().increaseHealth(10);
        }
    }


    // Start is called before the first frame update
    new void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() { }
}