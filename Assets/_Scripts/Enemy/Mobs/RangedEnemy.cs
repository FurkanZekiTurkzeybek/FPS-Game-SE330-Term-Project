using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyAI {
    private EnemyRifle _enemyRifle;

    protected override void combat() {
        if (Vector3.Distance(transform.position, playerLocation.position) < 5) {
            //if player is closer than 1 unit start the coroutine
            if (_isAttacking == false) {
                StartCoroutine(_enemyRifle.fire(true));
            }
            else {
                // StartCoroutine(_enemyRifle.fire(false));
            }
        }
    }


    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        _enemyRifle = gameObject.GetComponentInChildren<EnemyRifle>();
    }


    // Update is called once per frame
    void Update() { }
}