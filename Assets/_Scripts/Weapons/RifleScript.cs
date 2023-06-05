using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : MonoBehaviour {
    private int _ammoCount = 50;
    private int _ammoInMag = 10;
    private Rigidbody prefabBullet;
    public Rigidbody bullet;
    private Animator _magazineAnimator;
    private bool _hasToReload = false;
    private bool _outOfAmmo = false;
    
    protected float _bulletSpeed = 75;

    public void addAmmo(int bulletToBeAdded) {
        _ammoCount += bulletToBeAdded;
    }

    public int getAmmo() {
        return _ammoCount;
    }

    public int getAmmoInBullet() {
        return _ammoInMag;
    }

    public void resetAmmo() { //this method is used when the player dies.
        _ammoCount = 10;
    }

    public bool getReloadBool() {
        return _hasToReload;
    }

    public bool getOutOfAmmo() {
        return _outOfAmmo;
    }


    protected virtual IEnumerator fire() {
        while (true) {
            if (Input.GetKey(KeyCode.Mouse0)) {
                if (_ammoInMag > 0) {
                    shootBullet();
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

    protected void shootBullet() { //I made this in a different method so I can overwrite it in the enemy rifle
        prefabBullet = Instantiate(bullet, transform.position, transform.rotation);
        prefabBullet.velocity = transform.forward * _bulletSpeed;
    }


    // Start is called before the first frame update
    protected virtual void Start() {
        // _magazineAnimator = gameObject.GetComponentInChildren<Animator>();
        // StartCoroutine(fire());
    }

    private void OnEnable() {
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