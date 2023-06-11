using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : RangedWeapon {
    // protected int _ammoCount = 50;
    private int _ammoInMag = 10;
    private Rigidbody _prefabBullet;
    // public Rigidbody bullet;
    private Animator _magazineAnimator;
    private bool _hasToReload = false;
    // protected bool _outOfAmmo = false;

    // protected float _bulletSpeed = 75;

    // public override void addAmmo(int bulletToBeAdded) {
    //     _ammoCount += bulletToBeAdded;
    // }

    // public override int getAmmo() {
    //     return _ammoCount;
    // }

    public int getAmmoInBullet() {
        return _ammoInMag;
    }

    // public override void resetAmmo() { //this method is used when the player dies.
    //     _ammoCount = 10;
    // }

    public bool getReloadBool() {
        return _hasToReload;
    }

    public override bool getOutOfAmmo() {
        return base.getOutOfAmmo();
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
                _ammoCount -= 10;
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
        _ammoCount = 50;
    }

    protected void OnEnable() {
        _ammoSpeed = 75f;
        _magazineAnimator = gameObject.GetComponentInChildren<Animator>();
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update() {
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