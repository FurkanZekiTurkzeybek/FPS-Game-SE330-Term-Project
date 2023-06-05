using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUIScript : PlayerStatsUI {
    private Image[] _healthBars;

    // Start is called before the first frame update
    void Start() {
        _healthBars = gameObject.GetComponentsInChildren<Image>();
    }


    // Update is called once per frame
    void Update() {
        checkForStats(base.playerStats.getHealth, _healthBars);
    }
}