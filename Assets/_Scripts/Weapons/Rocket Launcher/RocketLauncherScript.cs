using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RocketLauncherScript : RangedWeapon {
    private Rigidbody _prefabrocket;
    // private int _ammoCount;

    public override void addAmmo(int rocketToBeAdded) {
        _ammoCount += rocketToBeAdded;
    }


    protected override IEnumerator fire() {
        while (true) {
            if (Input.GetKey(KeyCode.Mouse0) && _ammoCount > 0) {
                shoot();
                _ammoCount--;
                yield return new WaitForSeconds(1f);
            }

            yield return null;
        }
    }

    protected override void shoot() {
        _prefabrocket = Instantiate(ammunition, transform.position, Quaternion.Euler(
            new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z)));
        _prefabrocket.velocity = transform.forward * _ammoSpeed;
    }

    // Start is called before the first frame update
    void Start() {
        _ammoCount = 5;
    }

    protected void OnEnable() {
        _ammoSpeed = 8f;
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update() { }
}