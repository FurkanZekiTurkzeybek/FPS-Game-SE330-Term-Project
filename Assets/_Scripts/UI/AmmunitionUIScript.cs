using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmunitionUIScript : MonoBehaviour {
    public RifleScript rifleStats;
    private TextMeshProUGUI _ammoCount;
    // Start is called before the first frame update
    void Start() {
        _ammoCount = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        _ammoCount.text = "Ammo: "+ rifleStats.getAmmoInBullet()+ " / "+ rifleStats.getAmmo();
    }
}
