using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet {
    private int _rocketDamage = 60;
    private CapsuleCollider _rocketCollider;

    protected override void OnTriggerEnter(Collider other) {
        StartCoroutine(explodeRocket());
        if (other.gameObject.GetComponent<EnemyStats>()) {
            Debug.Log($"{GetType().Name}: if entered");
            _playerStats.setEnemyShot();
            _targetEnemy = other.gameObject;
            _targetEnemy.gameObject.GetComponent<EnemyStats>().getShot(_rocketDamage);
            Destroy(gameObject);
        }
    }

    private IEnumerator explodeRocket() {
        Debug.Log($"{GetType().Name}: exoplode CRTN Started");
        _rocketCollider.radius *= 5;
        _rocketCollider.height *= 5;
        yield return null;
    }

    // Start is called before the first frame update
    void Start() {
        base.Start();
        _rocketCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    private void OnEnable() { }

    // Update is called once per frame
    protected override void Update() {
        if (Vector3.Distance(currentLocation, gameObject.transform.position) > 15) {
            Debug.Log($"{GetType().Name}: Rocket destroyed due to its distance");
            Destroy(gameObject);
        }

        Destroy(gameObject, 10f);
    }
}