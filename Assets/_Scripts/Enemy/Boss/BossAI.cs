using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : EnemyAI {
    public Rigidbody horizontalAttackPrefab;
    public Rigidbody verticalAttackPrefab;
    private BossAttacker _bossAttackerScript;


    private IEnumerator bossFight() {
        while (true) {
            Vector3 newDirection = new Vector3(playerLocation.position.x, transform.position.y,
                playerLocation.position.z);
            transform.LookAt(newDirection);
            transform.position += transform.forward * (_enemyVelocity * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator verticalAttack(float verticalAttackCD) {
        while (true) {
            yield return new WaitForSeconds(1f);
            _bossAttackerScript.combat(verticalAttackPrefab);
            yield return new WaitForSeconds(verticalAttackCD);
        }
    }

    private IEnumerator horizontalAttack(float horizontalAttackCD) {
        while (true) {
            _bossAttackerScript.combat(horizontalAttackPrefab);
            yield return new WaitForSeconds(horizontalAttackCD);
        }
    }


    // Start is called before the first frame update
    protected override void Start() {
        _bossAttackerScript = gameObject.GetComponentInChildren<BossAttacker>();
        playerLocation = GameObject.FindWithTag("Player").transform;

        StartCoroutine(bossFight());
        StartCoroutine(verticalAttack(6f));
        StartCoroutine(horizontalAttack(3f));
    }

    // Update is called once per frame
    void Update() { }
}