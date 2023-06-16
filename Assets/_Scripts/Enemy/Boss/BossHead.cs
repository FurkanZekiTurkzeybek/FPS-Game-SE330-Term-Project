using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossHead : BossStats {
    private Vector3 _headInitialScale;
    private float _tweenPlayTime = 0.5f;
    public BossStats _bossStats;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Ammunition>() &&
            other.gameObject.GetComponent<EnemyBullet>() == false) {
            _bossStats.getHeadShot(other);
        }
    }

    protected override void die() {
        //do nothing there
    }

    private void changeHeadSizeTween() {
        transform.DOScale(_headInitialScale * 0.1f, _tweenPlayTime)
            .OnComplete(() =>
                transform.DOScale(_headInitialScale, _tweenPlayTime).OnComplete(changeHeadSizeTween));
    }


    // Start is called before the first frame update
    void Start() {
        initialColour = gameObject.GetComponent<Renderer>().material.color;

        _headInitialScale = gameObject.transform.localScale;

        changeHeadSizeTween();
    }

    // Update is called once per frame
    void Update() { }
}