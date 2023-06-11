using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : MonoBehaviour {
    protected int _ammoCount;
    protected bool _outOfAmmo = false;
    protected float _ammoSpeed;
    public Rigidbody ammunition;
    public PlayerStats playerStats;

    public abstract void addAmmo(int ammoToBeAdded);

    public virtual int getAmmo() {
        return _ammoCount;
    }


    public virtual void resetAmmo() { //this method is used when the player dies.
        _ammoCount = 10;
    }


    public virtual bool getOutOfAmmo() {
        return _outOfAmmo;
    }

    protected abstract IEnumerator fire();
    protected abstract void shoot();

    // Start is called before the first frame update
    void Start() {
        // playerStats = gameObject.GetComponentInParent<PlayerStats>();
    }

    // Update is called once per frame
    void Update() { }
}