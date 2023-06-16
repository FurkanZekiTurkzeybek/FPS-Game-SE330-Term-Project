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

    protected override void die() {
        // StartCoroutine(dieCoroutine());
        // _isDead = true;
        float tweenTime = 1f;
        transform.DOScale(_initialScale * 2, tweenTime).OnComplete(() => {
            transform.DOScale(_initialScale, tweenTime).OnComplete(() => {
                transform.DOScale(_initialScale * 2, tweenTime).OnComplete(() => died());
            });
        });
    }

    private void died() {
        Debug.Log("Died is working");
        SceneManager.LoadScene("GameOver");
        if (gameObject != null) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        _initialScale = gameObject.transform.localScale;
        health *= 1;
    }

    // Update is called once per frame
    void Update() {
        if (_isDead && _playingAnimation == false) {
            Destroy(gameObject);
        }

        Debug.Log(health);
    }
}