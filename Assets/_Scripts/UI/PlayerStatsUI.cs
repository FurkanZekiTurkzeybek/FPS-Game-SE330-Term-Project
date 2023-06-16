using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class PlayerStatsUI : MonoBehaviour {
    //This class is some kind of "Abstract class" it's not used in any game object, instead it used as a interface for
    //HealthUI and ArmourUI scripts
    public PlayerStats playerStats;

    public RectTransform symbolTransform;

    // private Image[] _symbolImages;
    // public Image symbolUpperPart;
    // public Image symbolLowerPart;
    // private Color _symbolInitialColour;

    protected void checkForStats(Func<int> statFunction, UnityEngine.UI.Image[] arrayOfBars) {
        if (statFunction() >= 80 && statFunction() < 100) {
            arrayOfBars[4].enabled = false;
            arrayOfBars[3].enabled = true;
            arrayOfBars[2].enabled = true;
            arrayOfBars[1].enabled = true;
            arrayOfBars[0].enabled = true;
        }

        if (statFunction() >= 60 && statFunction() < 80) {
            arrayOfBars[4].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[2].enabled = true;
            arrayOfBars[1].enabled = true;
            arrayOfBars[0].enabled = true;
        }

        if (statFunction() >= 40 && statFunction() < 60) {
            arrayOfBars[4].enabled = false;
            arrayOfBars[3].enabled = false;
            arrayOfBars[2].enabled = false;
            arrayOfBars[1].enabled = true;
            arrayOfBars[0].enabled = true;
        }

        if (statFunction() >= 20 && statFunction() < 40) {
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

    // internal void changeColour() {
    //     float tweenDuration = 0.40f;
    //     symbolUpperPart.material.DOColor(Color.red, tweenDuration).OnComplete(() => {
    //         symbolUpperPart.material.DOColor(_symbolInitialColour, tweenDuration);
    //     });
    //     symbolUpperPart.color = _symbolInitialColour;
    // }

    public void changeSymbolSize() {
        float tweenTime = 0.40f;

        symbolTransform.transform.DOScale(Vector3.one * 1.5f, tweenTime).OnComplete(() => {
            symbolTransform.transform.DOScale(Vector3.one, tweenTime);
        });
    }


    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}