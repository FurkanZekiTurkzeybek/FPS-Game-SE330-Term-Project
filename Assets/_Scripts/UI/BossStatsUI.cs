using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatsUI : MonoBehaviour {
    public GameObject panelOfHealths;
    public BossStats bossStats;
    private Image[] _listOfBars;
    private int _maxHealth;


    // Start is called before the first frame update
    void Start() {
        _maxHealth = 100;
        _listOfBars = panelOfHealths.gameObject.GetComponentsInChildren<Image>();
    }

    protected void checkForStats(Func<int> statFunction, UnityEngine.UI.Image[] arrayOfBars) {
        if (statFunction() >= 450 && statFunction() < 500) {
            arrayOfBars[0].enabled = false;
        }

        if (statFunction() >= 400 && statFunction() < 450) {
            arrayOfBars[0].enabled = false;
            arrayOfBars[1].enabled = false;
        }

        if (statFunction() >= 350 && statFunction() < 400) {
            arrayOfBars[0].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[2].enabled = false;
        }

        if (statFunction() >= 300 && statFunction() < 350) {
            arrayOfBars[0].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[3].enabled = false;
        }

        if (statFunction() >= 250 && statFunction() < 300) {
            arrayOfBars[0].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[4].enabled = false;
        }

        if (statFunction() >= 200 && statFunction() < 250) {
            arrayOfBars[0].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[4].enabled = false;
            arrayOfBars[5].enabled = false;
        }

        if (statFunction() >= 150 && statFunction() < 200) {
            arrayOfBars[0].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[4].enabled = false;
            arrayOfBars[5].enabled = false;
            arrayOfBars[6].enabled = false;
        }

        if (statFunction() >= 100 && statFunction() < 150) {
            arrayOfBars[0].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[4].enabled = false;
            arrayOfBars[5].enabled = false;
            arrayOfBars[6].enabled = false;
            arrayOfBars[7].enabled = false;
        }

        if (statFunction() >= 50 && statFunction() < 100) {
            arrayOfBars[0].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[4].enabled = false;
            arrayOfBars[5].enabled = false;
            arrayOfBars[6].enabled = false;
            arrayOfBars[7].enabled = false;
            arrayOfBars[8].enabled = false;
        }

        if (statFunction() >= 0 && statFunction() < 50) {
            arrayOfBars[0].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[4].enabled = false;
            arrayOfBars[5].enabled = false;
            arrayOfBars[6].enabled = false;
            arrayOfBars[7].enabled = false;
            arrayOfBars[8].enabled = false;
            arrayOfBars[9].enabled = false;
        }
    }

    // Update is called once per frame
    void Update() {
        checkForStats(bossStats.getHealth, _listOfBars);
    }
}