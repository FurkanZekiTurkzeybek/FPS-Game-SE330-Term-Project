using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : Bullet {
    private int _enemyBulletDamage = 10;
    protected override void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerStats>()) {
            setTarget(other.gameObject);
            _targetEnemy = other.gameObject;
            _targetEnemy.gameObject.GetComponent<PlayerStats>().receiveDamage(_enemyBulletDamage);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    new void Start() {
        base.Start();
    }

    // Update is called once per frame
    new void Update() {
        base.Update();
    }
}