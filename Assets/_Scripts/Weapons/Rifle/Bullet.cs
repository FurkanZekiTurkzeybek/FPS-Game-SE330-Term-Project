using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Ammunition {
    // protected Vector3 currentLocation;
    // protected int _bulletDamage = 10;
    // protected GameObject _targetEnemy;
    // protected PlayerStats _playerStats;


    //Protected and virtual is for enemy script
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
        // currentLocation = transform.position;
        // _playerStats = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerStats>();
    }


    // Update is called once per frame
    protected virtual void Update() {
        // if (Vector3.Distance(currentLocation, gameObject.transform.position) > 15) {
        //     Destroy(gameObject);
        // }
        base.Update();

        Destroy(gameObject, 2);
    }
}