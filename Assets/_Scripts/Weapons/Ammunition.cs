using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammunition : MonoBehaviour {
    protected Vector3 currentLocation;
    protected GameObject _targetEnemy;
    protected PlayerStats _playerStats;
    protected int ammunitionDamage;

    public int getAmmunitionDamage() {
        return this.ammunitionDamage;
    }

    protected abstract void OnTriggerEnter(Collider other);

    // Start is called before the first frame update
    protected virtual void Start() {
        currentLocation = transform.position;
        _playerStats = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    protected virtual void Update() {
        if (Vector3.Distance(currentLocation, gameObject.transform.position) > 25) {
            Destroy(gameObject);
        }
    }
}