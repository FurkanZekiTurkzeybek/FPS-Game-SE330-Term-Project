using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWheel : MonoBehaviour {
    public GameObject playersRifle;
    public GameObject playersSword;
    public GameObject playersRPG;
    public GameObject playersGrenade;
    private int _weaponIndex;

    private void selectWeapon(bool rifle, bool sword, bool rpg, bool grenade, int weaponIndex) {
        playersRifle.SetActive(rifle);
        playersSword.SetActive(sword);
        playersRPG.SetActive(rpg);
        playersGrenade.SetActive(grenade);
        _weaponIndex = weaponIndex;
    }

    public int getWeaponIndex() {
        return _weaponIndex;
    }

    // Start is called before the first frame update

    void Start() {
        _weaponIndex = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            selectWeapon(true, false, false, false, 0);
        }

        else if (Input.GetKey(KeyCode.Alpha2)) {
            selectWeapon(false, true, false, false, 1);
        }
        else if (Input.GetKey(KeyCode.Alpha3)) {
            selectWeapon(false, false, true, false, 2);
        }
        else if (Input.GetKey(KeyCode.G)) {
            selectWeapon(false, false, false, true, 3);
        }
    }
}