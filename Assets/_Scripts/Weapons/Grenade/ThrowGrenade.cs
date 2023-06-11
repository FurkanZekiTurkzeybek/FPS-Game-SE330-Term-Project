using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : RangedWeapon {
    private Rigidbody _prefabGrenade;
    private int _grenadeCount;

    public override void addAmmo(int grenadeToBeAdded) {
        _grenadeCount += grenadeToBeAdded;
    }

    protected override IEnumerator fire() {
        while (true) {
            if (Input.GetKey(KeyCode.Mouse0) && _grenadeCount > 0) {
                shoot();
                _grenadeCount--;
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
        _grenadeCount = 3;
    }

    protected void OnEnable() {
        _ammoSpeed = 10f;
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update() {
        Debug.Log($"Ammo count: {_grenadeCount}");
    }
}