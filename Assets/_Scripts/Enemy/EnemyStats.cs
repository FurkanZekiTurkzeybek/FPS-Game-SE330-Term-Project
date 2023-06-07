using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    private int _health = 100;
    private Animator _animator;
    private LineRenderer[] _healthBar;
    private Color _initialColour;


    private void recieveDamage(int damageReceived) {
        _health -= damageReceived;
    }

    private void getShotTween() {
        float tweenTime = 0.15f;
        Material enemyMaterial = gameObject.GetComponent<Renderer>().material;
        enemyMaterial.DOColor(Color.red, tweenTime).SetLoops(1, LoopType.Restart)
            .OnComplete(() => {
                enemyMaterial.DOColor(_initialColour, tweenTime)
                    .SetLoops(1, LoopType.Restart);
            });
    }

    private void die() {
        // _animator.SetTrigger("die");
        // Destroy(gameObject);

        StartCoroutine(dieCoroutine());
    }

    private IEnumerator dieCoroutine() {
        _animator.SetTrigger("die");
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
    }

    public void getShot(int damageToBeReceived) {
        getShotTween();

        if (damageToBeReceived >= _health) {
            die();
        }

        else {
            recieveDamage(damageToBeReceived);
        }
    }

    private void changeColourOnShot() { }


    // Start is called before the first frame update
    void Start() {
        _animator = gameObject.GetComponent<Animator>();
        _healthBar = gameObject.GetComponentsInChildren<LineRenderer>();
        _initialColour = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update() {
        if (_health == 0) {
            die();
        }


        if (_health < 100) {
            _healthBar[0].enabled = false;
        }

        if (_health < 80) {
            _healthBar[1].enabled = false;
        }

        if (_health < 60) {
            _healthBar[2].enabled = false;
        }

        if (_health < 40) {
            _healthBar[3].enabled = false;
        }

        if (_health < 20) {
            _healthBar[4].enabled = false;
        }
    }
}