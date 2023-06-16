using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalk : MonoBehaviour {
    private Vector3 _currentJumpVelocity;

    private bool _isJumping;

    public Transform extra;

    private CharacterController _controller;

    public bool getJump() {
        return _isJumping;
    }

    public CharacterController getConroller() {
        return _controller;
    }

    // Start is called before the first frame update
    void Start() {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    private float _velocity = 2.5f;

    // Update is called once per frame
    void Update() {
        Vector3 moveVelocity = Vector3.zero;

        moveVelocity.x = Input.GetAxis("Horizontal");
        moveVelocity.z = Input.GetAxis("Vertical");

        if (Input.GetKeyUp(KeyCode.Space)) {
            if (!_isJumping) {
                jump();
            }
        }

        //Jumping case
        if (_isJumping) {
            //Sprint jump
            if (Input.GetKey(KeyCode.LeftShift)) {
                _controller.Move(extra.localRotation * (moveVelocity * 3 + _currentJumpVelocity) * Time.deltaTime);
                _currentJumpVelocity += Physics.gravity * Time.deltaTime;
            }
            else {
                _controller.Move(extra.localRotation * (moveVelocity + _currentJumpVelocity) * Time.deltaTime);
                _currentJumpVelocity += Physics.gravity * Time.deltaTime;
            }

            if (_controller.isGrounded) {
                _isJumping = false;
            }
        }
        else {
            _controller.SimpleMove(extra.localRotation * moveVelocity * _velocity);
        }

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift) && _controller.isGrounded) {
            _controller.SimpleMove(extra.localRotation * (moveVelocity * 3));
        }
    }

    public void jump() {
        _isJumping = true;
        _currentJumpVelocity = Vector3.up * 4;
    }
}