using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rocket : Bullet {
    private int _rocketDamage = 60;
    private CapsuleCollider _rocketCollider;
    private Vector3 _rocketInitialScale;
    private bool _isDestroyed = false;

    protected override void OnTriggerEnter(Collider other) {
        float explosionScale = 4f;
        float twennPlayTime = 1f;
        if (_isDestroyed == false && other.gameObject.GetComponent<EnemyStats>()) {
            transform.DOMove(transform.position, twennPlayTime).OnPlay(() => {
                transform.DOScale(_rocketInitialScale * explosionScale, twennPlayTime).OnPlay(() => {
                        gameObject.GetComponent<Renderer>().material.DOColor(Color.yellow, twennPlayTime);
                        _rocketCollider.radius = explosionScale;
                        _rocketCollider.height = explosionScale;
                        _playerStats.setEnemyShot();
                        _targetEnemy = other.gameObject;
                        _targetEnemy.gameObject.GetComponent<EnemyStats>().getShot(_rocketDamage);
                    })
                    .OnComplete(() => Destroy(gameObject)).OnComplete(() => _isDestroyed = true);
            });
        }
    }


    // Start is called before the first frame update
    void Start() {
        base.Start();
        _rocketCollider = gameObject.GetComponent<CapsuleCollider>();
        _rocketInitialScale = gameObject.transform.localScale;
    }

    private void OnEnable() { }

    // Update is called once per frame
    protected override void Update() {
        if (Vector3.Distance(currentLocation, gameObject.transform.position) > 15) {
            Destroy(gameObject);
        }

        Destroy(gameObject, 10f);
    }
}