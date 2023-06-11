using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : RangedWeapon {
    private int _ammoInMag = 10;
    private Rigidbody _prefabBullet;
    private Animator _magazineAnimator;
    private bool _hasToReload = false;

    public override void addAmmo(int ammoToBeAdded) {
        playerStats.addBullet(ammoToBeAdded);
    }

    public int getAmmoInMag() {
        return _ammoInMag;
    }


    public bool getReloadBool() {
        return _hasToReload;
    }


    protected override IEnumerator fire() {
        while (true) {
            if (Input.GetKey(KeyCode.Mouse0)) {
                if (_ammoInMag > 0) {
                    shoot();
                    _ammoInMag--;
                    yield return new WaitForSeconds(0.30f);
                }
            }
            else if (Input.GetKey(KeyCode.R) && _ammoCount >= 10) {
                _ammoInMag = 10;
                playerStats.reload();
                // _ammoCount -= 10;
                //Play the reload animation.
                _magazineAnimator.SetTrigger("reloadPressed");
                yield return new WaitForSeconds(1f);
            }

            yield return null;
        }
    }

    protected override void shoot() { //I made this in a different method so I can overwrite it in the enemy rifle
        _prefabBullet = Instantiate(ammunition, transform.position, transform.rotation);
        _prefabBullet.velocity = transform.forward * _ammoSpeed;
    }


    // Start is called before the first frame update
    protected virtual void Start() {
        _ammoCount = playerStats.getBulletCount();
    }

    protected void OnEnable() {
        _ammoCount = playerStats.getBulletCount();
        _ammoSpeed = 75f;
        _magazineAnimator = gameObject.GetComponentInChildren<Animator>();
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update() {
        _ammoCount = playerStats.getBulletCount();

        if (_ammoInMag == 0 && _ammoCount > 0) {
            _hasToReload = true;
            _outOfAmmo = false;
        }
        else if (_ammoInMag == 0 && _ammoCount == 0) {
            _hasToReload = false;
            _outOfAmmo = true;
        }
        else {
            _hasToReload = false;
            _outOfAmmo = false;
        }
    }
}