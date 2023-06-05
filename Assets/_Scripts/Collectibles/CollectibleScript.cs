using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CollectibleScript : MonoBehaviour {
    private Vector3 _collectibleInitialScale;
    private float _tweenPlayTime = 0.5f;
    private bool _isDestroyed = false;

    protected void OnTriggerEnter(Collider other) {
        if (!_isDestroyed) {
            _isDestroyed = true;
            transform.DOScale(_collectibleInitialScale * 2, _tweenPlayTime)
                .OnComplete(() =>
                    transform.DOScale(_collectibleInitialScale, _tweenPlayTime).OnComplete(destroyCollectible));
        }
    }

    private void destroyCollectible() {
        if (gameObject != null) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    protected void Start() {
        if (gameObject != null) {
            _collectibleInitialScale = gameObject.transform.localScale;
        }
    }

    // Update is called once per frame
    void Update() { }
}