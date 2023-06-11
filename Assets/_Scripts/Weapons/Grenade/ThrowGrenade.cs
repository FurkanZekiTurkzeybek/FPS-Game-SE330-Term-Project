using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : RifleScript {
    private Rigidbody _prefabGrenade;
    

    protected override IEnumerator fire() {
        while (true) {
            if (Input.GetKey(KeyCode.Mouse0)) {
                shoot();
                yield return new WaitForSeconds(2f);
            }

            yield return null;
        }
    }

    protected override void shoot() {
        _prefabGrenade = Instantiate(bullet, transform.position,
            transform.rotation);
        _prefabGrenade.velocity = transform.forward * _bulletSpeed;
    }

    // Start is called before the first frame update
    void Start() { }

    protected void OnEnable() {
        _bulletSpeed = 10f;
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update() { }
}