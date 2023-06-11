using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Grenade : Bullet {
    private int _grenadeDamage = 80;
    private SphereCollider _grenadeCollider;
    private Vector3 _grenadeInitialScale;
    private bool _isDestroyed = false;
    private bool _finishedJumping = false;

    protected override void OnTriggerEnter(Collider other) {
        if (_finishedJumping == true && other.gameObject.GetComponent<EnemyStats>()) {
            _playerStats.setEnemyShot();
            other.gameObject.GetComponent<EnemyStats>().getShot(_grenadeDamage);
        }
    }

    private void hopTween() {
        float bounceHeight = 1.5f;
        float twennPlayTime = 3f;
        float explosionScale = 5f;
        transform.DOJump(transform.position + transform.forward * 6f,
                bounceHeight, 3, twennPlayTime)
            .OnComplete(() => {
                transform.DOScale(explosionScale, 1f)
                    .OnPlay(() => {
                        _finishedJumping = true;
                        _grenadeCollider.radius *= 2f;
                    })
                    .OnComplete(() => { Destroy(gameObject); });
            });
    }

    // Start is called before the first frame update
    void Start() {
        base.Start();
        _grenadeCollider = gameObject.GetComponent<SphereCollider>();
        _grenadeInitialScale = gameObject.transform.localScale;
        hopTween();
    }

    // Update is called once per frame
    void Update() { }
}