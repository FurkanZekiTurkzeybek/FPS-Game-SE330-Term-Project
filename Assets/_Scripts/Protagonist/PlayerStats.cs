using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
    public HealthUIScript healthUIScript;
    public ArmourUIScript armourUIScript;
    private int _health = 100;
    private int _armour = 0;
    private bool isDead = false;
    private bool _enemyShot = false;

    private int _bulletCount = 50;
    private int _rocketCount = 10;
    private int _grenadeCount = 3;
    private int _enemyKillCount = 0;


    private int _requiredKillCount = 10;
    private bool _readyForLevelTwo = false;
    private bool _firstLevelFinished = false;


    public void addBullet(int bulletToBeAdded) {
        _bulletCount += bulletToBeAdded;
    }

    public void addRocket(int rocketToBeAdded) {
        _rocketCount += rocketToBeAdded;
    }

    public void addGrenade(int grenadeToBeAdded) {
        _grenadeCount += grenadeToBeAdded;
    }

    public int getBulletCount() {
        return _bulletCount;
    }

    public int getRocketCount() {
        return _rocketCount;
    }

    public int getGrenadeCount() {
        return _grenadeCount;
    }


    public bool getEnemyShot() {
        return _enemyShot;
    }

    public void setEnemyShot() {
        StartCoroutine(setShot());
    }

    public void reload() {
        _bulletCount -= 10;
    }

    public void setGrenade(int newGrenadeCount) {
        _grenadeCount = newGrenadeCount;
    }

    public void setRocket(int newRocketCount) {
        _rocketCount = newRocketCount;
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

    public int getKillCount() {
        return _enemyKillCount;
    }

    public void increaseKillCount() {
        _enemyKillCount++;
    }

    public int getRequieredKillCount() {
        return _requiredKillCount;
    }

    public bool getReadyForLevelTwo() {
        return _readyForLevelTwo;
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

    public void changeLevels() {
        _firstLevelFinished = true;
    }

    public bool getFirstLeveFinished() {
        return _firstLevelFinished;
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
        if (_enemyKillCount == _requiredKillCount) {
            _readyForLevelTwo = true;
        }

        if (isDead == true) {
            SceneManager.LoadScene("YouDied");
        }
    }
}