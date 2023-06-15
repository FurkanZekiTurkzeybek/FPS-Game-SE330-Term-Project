using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : EnemyStats {
    
    public void getHeadShot(Collider other) {
        health -= 2 * other.gameObject.GetComponent<Ammunition>().getAmmunitionDamage();
    }

    protected override void die() {
        // Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start() {
        health *= 5;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(health);
    }
}