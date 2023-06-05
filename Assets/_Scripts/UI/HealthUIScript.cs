using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUIScript : PlayerStatsUI {
    // public PlayerStats playerStats;
    private Image[] _healthBars;

    // Start is called before the first frame update
    void Start() {
        _healthBars = gameObject.GetComponentsInChildren<Image>();
    }

    // private void checkHealth() {
    //     if (playerStats.getHealth() >= 80 && playerStats.getHealth() < 100) {
    //         _healthBars[4].enabled = false;
    //         _healthBars[3].enabled = true;
    //         _healthBars[2].enabled = true;
    //         _healthBars[1].enabled = true;
    //         _healthBars[0].enabled = true;
    //     }
    //     if (playerStats.getHealth() >= 60 &&playerStats.getHealth() < 80) {
    //         _healthBars[4].enabled = false;
    //         _healthBars[3].enabled = false;
    //         _healthBars[2].enabled = true;
    //         _healthBars[1].enabled = true;
    //         _healthBars[0].enabled = true;
    //     }
    //
    //     if (playerStats.getHealth() >= 40 &&playerStats.getHealth() < 60) {
    //         _healthBars[4].enabled = false;
    //         _healthBars[3].enabled = false;
    //         _healthBars[2].enabled = false;
    //         _healthBars[1].enabled = true;
    //         _healthBars[0].enabled = true;
    //     }
    //
    //     if (playerStats.getHealth() >= 20 &&playerStats.getHealth() < 40) {
    //         _healthBars[4].enabled = false;
    //         _healthBars[3].enabled = false;
    //         _healthBars[2].enabled = false;
    //         _healthBars[1].enabled = true;
    //         _healthBars[0].enabled = true;
    //     }
    //
    //     if (playerStats.getHealth() >= 0 && playerStats.getHealth() < 20) {
    //         _healthBars[4].enabled = false;
    //         _healthBars[3].enabled = false;
    //         _healthBars[2].enabled = false;
    //         _healthBars[1].enabled = false;
    //         _healthBars[0].enabled = true;
    //     }
    // }

    // Update is called once per frame
    void Update() {
        // checkHealth();
        checkForStats(base.playerStats.getHealth, _healthBars);
    }
}