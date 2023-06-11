using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : RangedWeapon {
    private Rigidbody _prefabGrenade;

    public override void addAmmo(int grenadeToBeAdded) {
        _ammoCount += grenadeToBeAdded;
    }


    protected override IEnumerator fire() {
        while (true) {
            if (Input.GetKey(KeyCode.Mouse0) && _ammoCount > 0) {
                shoot();
                _ammoCount--;
                yield return new WaitForSeconds(2f);
            }

            yield return null;
        }
    }

    protected override void shoot() {
        _prefabGrenade = Instantiate(ammunition, transform.position,
            transform.rotation);
        _prefabGrenade.velocity = transform.forward * _ammoSpeed;
    }

    // Start is called before the first frame update
    void Start() {
        _ammoCount = 3;
    }

    protected void OnEnable() {
        _ammoSpeed = 10f;
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update() { }
}