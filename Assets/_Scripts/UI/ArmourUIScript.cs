using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmourUIScript : PlayerStatsUI {
    // public GameObject armourSymbol;
    private Image[] _armourBars;

    // Start is called before the first frame update
    void Start() {
        _armourBars = gameObject.GetComponentsInChildren<Image>();
    }


    // Update is called once per frame
    void Update() {
        checkForStats(base.playerStats.getArmour, _armourBars);
    }
}