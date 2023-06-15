using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : EnemyAI {
    public Rigidbody horizontalAttackPrefab;
    public Rigidbody verticalAttackPrefab;


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
            combat(verticalAttackPrefab);
            yield return new WaitForSeconds(verticalAttackCD);
        }
    }

    private IEnumerator horizontalAttack(float horizontalAttackCD) {
        while (true) {
            combat(horizontalAttackPrefab);
            yield return new WaitForSeconds(horizontalAttackCD);
        }
    }

    private void combat(Rigidbody attackPrefab) {
        float attackSpeed = 5f;
        attackPrefab = Instantiate(attackPrefab, transform.position, transform.rotation);
        attackPrefab.velocity = transform.forward * attackSpeed;
    }

    private IEnumerator wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
    }


    // Start is called before the first frame update
    protected override void Start() {
        playerLocation = GameObject.FindWithTag("Player").transform;

        StartCoroutine(bossFight());
        StartCoroutine(verticalAttack(10f));
        StartCoroutine(wait(2f));
        StartCoroutine(horizontalAttack(5f));
    }

    // Update is called once per frame
    void Update() { }
}