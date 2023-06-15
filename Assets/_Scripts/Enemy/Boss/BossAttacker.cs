using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacker : EnemyRifle {
    public Rigidbody secondAttack;

    public void combat(Rigidbody attackPrefab) {
        Debug.Log("Boss attack is working");
        float attackSpeed = 5f;
        attackPrefab = Instantiate(attackPrefab, transform.position, transform.rotation);
        attackPrefab.velocity = transform.forward * attackSpeed;
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}