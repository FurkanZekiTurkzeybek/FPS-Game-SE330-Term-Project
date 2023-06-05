using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStatsUI : MonoBehaviour
{
    public PlayerStats playerStats;

    protected void checkForStats(Func<int> statFunction, UnityEngine.UI.Image[] arrayOfBars) {
        if (statFunction() >= 80 && statFunction() < 100) {
            arrayOfBars[4].enabled = false;
            arrayOfBars[3].enabled = true;
            arrayOfBars[2].enabled = true;
            arrayOfBars[1].enabled = true;
            arrayOfBars[0].enabled = true;
        }
        if (statFunction() >= 60 &&statFunction() < 80) {
            arrayOfBars[4].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[2].enabled = true;
            arrayOfBars[1].enabled = true;
            arrayOfBars[0].enabled = true;
        }

        if (statFunction() >= 40 &&statFunction() < 60) {
            arrayOfBars[4].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[1].enabled = true;
            arrayOfBars[0].enabled = true;
        }

        if (statFunction() >= 20 &&statFunction() < 40) {
            arrayOfBars[4].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[0].enabled = true;
        }

        if (statFunction() > 0 && statFunction() < 20) {
            arrayOfBars[4].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[0].enabled = true;
        }

        if (statFunction() == 0) {
            arrayOfBars[4].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[1].enabled = false;
            arrayOfBars[0].enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
