using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPackScript : CollectibleScript {
    void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        if (other.gameObject.GetComponent<PlayerStats>()) {
            // Destroy(gameObject);
            other.gameObject.GetComponentInChildren<PlayerStats>().addBullet(10);
        }
    }

    // Start is called before the first frame update
    void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() { }
}