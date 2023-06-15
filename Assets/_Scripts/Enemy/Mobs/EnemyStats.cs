using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    protected int health = 100;
    private Animator _animator;
    private LineRenderer[] _healthBar;
    protected Color initialColour;


    private void recieveDamage(int damageReceived) {
        health -= damageReceived;
    }

    private void getShotTween() {
        float tweenTime = 0.15f;
        Material enemyMaterial = gameObject.GetComponent<Renderer>().material;
        enemyMaterial.DOColor(Color.red, tweenTime).SetLoops(1, LoopType.Restart)
            .OnComplete(() => {
                enemyMaterial.DOColor(initialColour, tweenTime)
                    .SetLoops(1, LoopType.Restart);
            });
    }

    protected virtual void die() {
        GameObject.FindWithTag("Player").GetComponent<PlayerStats>().increaseKillCount();

        StartCoroutine(dieCoroutine());
    }

    private IEnumerator dieCoroutine() {
        _animator.SetTrigger("die");
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
    }

    public void getShot(int damageToBeReceived) {
        getShotTween();

        if (damageToBeReceived >= health) {
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
        initialColour = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update() {
        if (health == 0) {
            die();
        }

        if (health < 100) {
            _healthBar[0].enabled = false;
        }

        if (health < 80) {
            _healthBar[1].enabled = false;
        }

        if (health < 60) {
            _healthBar[2].enabled = false;
        }

        if (health < 40) {
            _healthBar[3].enabled = false;
        }

        if (health < 20) {
            _healthBar[4].enabled = false;
        }
    }
}