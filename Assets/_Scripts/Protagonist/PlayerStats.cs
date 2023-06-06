using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public HealthUIScript healthUIScript;
    public ArmourUIScript armourUIScript;
    private int _health = 100;
    private int _armour = 0;
    private bool isDead = false;
    private bool _enemyShot = false;

    public bool getEnemyShot() {
        return _enemyShot;
    }

    public void setEnemyShot() {
        StartCoroutine(setShot());
    }

    private IEnumerator setShot() {
        if (_enemyShot == false) {
            _enemyShot = true;
            yield return new WaitForSeconds(1f);
            _enemyShot = false;
        }
    }

    public int getHealth() {
        return _health;
    }

    public int getArmour() {
        return _armour;
    }

    public bool getDead() {
        return isDead;
    }

    public void increaseHealth(int healthToBeAdded) {
        healthUIScript.changeSymbolSize();
        if (getHealth() < 100) {
            if (getHealth() + healthToBeAdded > 100) {
                _health = 100;
            }
            else {
                _health += healthToBeAdded;
            }
        }
        else if (_health >= 100) {
            _health = 100;
        }
    }


    public void increaseArmour(int armourToBeAdded) {
        armourUIScript.changeSymbolSize();
        if (_armour < 100) {
            if (_armour + armourToBeAdded > 100) {
                _armour = 100;
            }
            else {
                _armour += armourToBeAdded;
            }
        }
    }

    public void receiveDamage(int damageReceived) {
        if (_armour > 0) {
            //do the armour checks
            if (damageReceived < _armour) {
                _armour -= damageReceived;
            }
            else if (damageReceived > _armour) {
                int depleteHealt = damageReceived - _armour;
                _health -= depleteHealt;
            }
            else {
                _armour = 0;
            }
        }
        else { //if the player has no armour
            _health -= damageReceived;
        }
    }

    public void checkHealth() {
        if (getHealth() <= 0) {
            isDead = true;
        }
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        checkHealth();

        if (isDead == true) {
            // Debug.Log("You are dead");
        }
    }
}