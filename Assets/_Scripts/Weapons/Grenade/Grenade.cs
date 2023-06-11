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
        // _grenadeCollider.isTrigger = false;
        float bounceHeight = 1.5f;
        float twennPlayTime = 3f;
        float explosionScale = 5f;
        transform.DOJump(transform.position + transform.forward * 6f,
                bounceHeight, 3, twennPlayTime)
            .OnComplete(() => {
                transform.DOScale(explosionScale, 1f)
                    .OnPlay(() => {
                        _grenadeCollider.isTrigger = true;
                        gameObject.GetComponent<Renderer>()
                            .material.DOColor(Color.yellow, 1f);
                        _finishedJumping = true;
                        _grenadeCollider.radius *= 2f;
                    })
                    .OnComplete(() => { Destroy(gameObject); });
            });
    }
    // private int _hopCount = 3;
    //
    // protected override void OnTriggerEnter(Collider other) {
    //     Debug.Log($"Touched with {other.gameObject.GetType().FullName}");
    //     Debug.Log($"Hop count  {_hopCount}");
    //
    //     float bounceHeight = 1.5f;
    //     float twennPlayTime = 3f;
    //     float explosionScale = 5f;
    //     if (_hopCount > 0 && _isDestroyed == false) {
    //         transform.DOJump(transform.position + transform.forward * 6f, bounceHeight, _hopCount,
    //                 twennPlayTime)
    //             .OnPlay(() => { _hopCount--; })
    //             .OnComplete(() => {
    //                 if (_hopCount == 0 && other.gameObject.GetComponent<EnemyStats>()) {
    //                     transform.DOScale(explosionScale, 1f)
    //                         .OnPlay(() => {
    //                             gameObject.GetComponent<Renderer>()
    //                                 .material.DOColor(Color.yellow, 1f);
    //                             _grenadeCollider.radius *= 2f;
    //                             _playerStats.setEnemyShot();
    //                             other.gameObject.GetComponent<EnemyStats>().getShot(_grenadeDamage);
    //                         })
    //                         .OnComplete(() => Destroy(gameObject))
    //                         .OnComplete(() => _isDestroyed = true);
    //                 }
    //             });
    //     }
    // }


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