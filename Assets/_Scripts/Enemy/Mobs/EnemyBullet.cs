using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : Bullet {
    // private int _enemyBulletDamage = 20;
    protected override void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerStats>()) {
            setTarget(other.gameObject);
            _targetEnemy = other.gameObject;
            _targetEnemy.gameObject.GetComponent<PlayerStats>().receiveDamage(ammunitionDamage);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    new void Start() {
        base.Start();
        ammunitionDamage = 20;
    }

    // Update is called once per frame
    new void Update() {
        base.Update();
    }
}