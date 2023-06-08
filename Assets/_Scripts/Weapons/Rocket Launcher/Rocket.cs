using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rocket : Bullet {
    private int _rocketDamage = 60;
    private CapsuleCollider _rocketCollider;
    private Vector3 _rocketInitialScale;

    protected override void OnTriggerEnter(Collider other) {
        float explosionScale = 3f;
        Vector3 positionAtContact = gameObject.transform.position;
        if (other.gameObject.GetComponent<EnemyStats>()) {
            if (gameObject != null) {
                transform.DOScale(_rocketInitialScale * explosionScale, 1f).OnPlay(() => {
                        _rocketCollider.radius = explosionScale;
                        _rocketCollider.height = explosionScale;
                        _playerStats.setEnemyShot();
                        _targetEnemy = other.gameObject;
                        _targetEnemy.gameObject.GetComponent<EnemyStats>().getShot(_rocketDamage);
                    })
                    .OnComplete(() => destroyRocket());
            }
        }
    }

    private void destroyRocket() {
        if (gameObject != null) {
            Destroy(gameObject);
        }
    }

    // private void explodeRocket(Collider other) {
    //     if (gameObject != null) {
    //         transform.DOScale(_rocketInitialScale * 5f, 1f).OnPlay(() => {
    //                 _rocketCollider.radius = 10;
    //                 _rocketCollider.height = 10;
    //                 _playerStats.setEnemyShot();
    //                 _targetEnemy = other.gameObject;
    //                 _targetEnemy.gameObject.GetComponent<EnemyStats>().getShot(_rocketDamage);
    //             })
    //             .OnComplete(() => { Destroy(gameObject); });
    //     }
    // }


    // Start is called before the first frame update
    void Start() {
        if (gameObject != null) {
            base.Start();
            _rocketCollider = gameObject.GetComponent<CapsuleCollider>();
            _rocketInitialScale = gameObject.transform.localScale;
        }
    }

    private void OnEnable() { }

    // Update is called once per frame
    protected override void Update() {
        if (gameObject != null) {
            if (Vector3.Distance(currentLocation, gameObject.transform.position) > 15) {
                Destroy(gameObject);
            }

            Destroy(gameObject, 10f);
        }
    }
}