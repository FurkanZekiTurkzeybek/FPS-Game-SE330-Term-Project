using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStats : EnemyStats {
    // public Animator bossAnimator;
    private bool _isDead = false;
    private bool _playingAnimation = false;
    private Vector3 _initialScale;

    public void getHeadShot(Collider other) {
        health -= 2 * other.gameObject.GetComponent<Ammunition>().getAmmunitionDamage();
    }

    public int getHealth() {
        return health;
    }

    protected override void die() {
        float tweenTime = 1f;
        transform.DOScale(_initialScale * 2, tweenTime)
            .OnComplete(() => {
                transform.DOScale(_initialScale, tweenTime).OnComplete(() => {
                    transform.DOScale(_initialScale * 2, tweenTime)
                        .OnComplete(() => {
                            transform.DOScale(_initialScale, tweenTime)
                                .OnComplete(() => {
                                    transform.DOScale(_initialScale * 2, tweenTime)
                                        .OnComplete(() => died());
                                });
                        })
                        ;
                });
            });
    }

    private void died() {
        SceneManager.LoadScene("GameOver");
        if (gameObject != null) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        initialColour = gameObject.GetComponent<Renderer>().material.color;
        _initialScale = gameObject.transform.localScale;
        health *= 5;
    }

    // Update is called once per frame
    void Update() {
        if (_isDead && _playingAnimation == false) {
            Destroy(gameObject);
        }
    }
}