using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmunitionUIScript : MonoBehaviour {
    public RifleScript rifleStats;
    public RocketLauncherScript rocketStats;
    public ThrowGrenade grenadeStats;
    public WeaponWheel weaponWheel;
    private TextMeshProUGUI _ammoCount;

    private void setWeaponOnUI() {
        if (weaponWheel.getWeaponIndex() == 0) {
            _ammoCount.text = "Bullet: " + rifleStats.getAmmoInMag() + " / " + rifleStats.getAmmo();
        }
        else if (weaponWheel.getWeaponIndex() == 1) {
            _ammoCount.text = "Sword ";
        }
        else if (weaponWheel.getWeaponIndex() == 2) {
            _ammoCount.text = "Rocket: " + rocketStats.getAmmo();
        }
        else if (weaponWheel.getWeaponIndex() == 3) {
            _ammoCount.text = "Grenade: " + grenadeStats.getAmmo();
        }
    }

    // Start is called before the first frame update
    void Start() {
        _ammoCount = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        setWeaponOnUI();
    }
}