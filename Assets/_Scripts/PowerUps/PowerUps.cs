using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public CharacterWalk charWalk;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(doubleJump(1f));
    }


    public IEnumerator dashCoroutine() {
        float dashLength = 2;
        float duration = 1;

        for (float t = 0; t <= duration; t += Time.deltaTime) {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0;
            Vector3 localMovement = transform.TransformDirection(cameraForward) * (dashLength * (10 * Time.deltaTime));

            transform.position += localMovement;

            yield return null;
        }
    }


    private bool _jumpPressed = false;
    private float _doubleJumpDelay = 0.5f;
    private float _lastJumpTime = 0f;
    private int _jumpCount = 0;


    public IEnumerator doubleJump(float jumpTime) {
        while (true) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (Time.time - _lastJumpTime < _doubleJumpDelay) {
                    if (charWalk.getConroller().isGrounded == false && _jumpCount == 1) {
                        charWalk.jump();
                        _jumpCount = 0;
                    }
                }
                else {
                    _jumpCount = 1;
                }

                _lastJumpTime = Time.time;
            }

            yield return null;
        }
    }


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Mouse1)) {
            StartCoroutine(dashCoroutine());
        }
    }
}