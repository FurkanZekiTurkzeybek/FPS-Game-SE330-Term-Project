using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    private int _damage = 50;

    private bool _swinging = false;

    private PlayerStats _player;

    public void invertSwing() {
        _swinging = !_swinging;
    }

    private GameObject _targetEnemy;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<EnemyStats>() && _swinging) {
            _player.setEnemyShot();
            _targetEnemy = other.gameObject;
            _targetEnemy.GetComponent<EnemyStats>().getShot(_damage);
        }
    }


    // Start is called before the first frame update

    void Start() {
        _player = GetComponentInParent<PlayerStats>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Mouse0)) {
            gameObject.GetComponent<Animator>().SetTrigger("attackPressed");
        }
    }
}