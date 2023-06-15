using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : EnemyBullet {
    // Start is called before the first frame update
    void Start() {
        base.Start();
        _bulletDamage = 40;
    }

    // Update is called once per frame
    protected override void Update() {
        if (Vector3.Distance(currentLocation, gameObject.transform.position) > 50) {
            Destroy(gameObject);
        }
        Destroy(gameObject, 10f);
    }
}