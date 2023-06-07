using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRifle : RifleScript {
    private bool inCD = false;
    private float cdTime = 1.5f;

    public IEnumerator fire(bool enemyDetected) {
        if (inCD == false) {
            inCD = true;
            shoot();
            yield return new WaitForSeconds(cdTime);
            inCD = false;
        }
        // yield return null;
    }

    protected override IEnumerator fire() {
        yield return null;
    }

    // Start is called before the first frame update
    protected override void Start() {
        _bulletSpeed = 25;
    }

    // Update is called once per frame
    void Update() { }
}