using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Ammunition {
    protected void setTarget(GameObject newTarget) {
        _targetEnemy = newTarget;
    }


    protected override void OnTriggerEnter(Collider other) {
        //I made this in a different method so I can overwrite it in the enemy rifle
        if (other.gameObject.GetComponent<EnemyStats>()) {
            _playerStats.setEnemyShot();
            _targetEnemy = other.gameObject;
            _targetEnemy.gameObject.GetComponent<EnemyStats>().getShot(ammunitionDamage);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update

    protected override void Start() {
        base.Start();
        ammunitionDamage = 10;
    }


    // Update is called once per frame
    protected virtual void Update() {
        base.Update();

        Destroy(gameObject, 5);
    }
}