using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy : EnemyAI {
    private GameObject _player;
    private Animator _animator;

    // protected bool _isAttacking;
    private float _meleeAttackCooldown = 5f;
    private RifleScript thisEnemyRifle;
    private int _enemySwordDamage = 10;


    private IEnumerator attackMelee() {
        _isAttacking = true;
        _player = playerLocation.gameObject;
        _animator.SetTrigger("attack");
        _player.GetComponent<PlayerStats>().receiveDamage(_enemySwordDamage);
        // _animator.ResetTrigger("attack");
        yield return new WaitForSeconds(_meleeAttackCooldown);

        _isAttacking = false;
    }

    protected override void combat() {
        if (Vector3.Distance(transform.position, playerLocation.position) <= 1) {
            //if player is closer than 1 unit start the coroutine
            if (_isAttacking == false) {
                StartCoroutine(attackMelee());
            }
        }
    }

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        _animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() { }
}