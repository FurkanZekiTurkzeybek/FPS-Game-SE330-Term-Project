using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalk : MonoBehaviour
{
    private Vector3 _currentJumpVelocity;

    private bool _isJumping;

    public Transform extra;

    private CharacterController _controller;
    

    // Start is called before the first frame update
    void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // CharacterController controller = gameObject.GetComponent<CharacterController>();
        Vector3 moveVelocity = Vector3.zero;

        moveVelocity.x = Input.GetAxis("Horizontal");
        moveVelocity.z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            if (!_isJumping)
            {
                _isJumping = true;
                _currentJumpVelocity = Vector3.up * 4;
            }
        }
        
        //Jumping case
        if (_isJumping)
        {
            //Sprint jump
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _controller.Move(extra.localRotation * ((moveVelocity * 3) + _currentJumpVelocity) * Time.deltaTime);
                _currentJumpVelocity += Physics.gravity * Time.deltaTime;
            }
            else
            {
                _controller.Move(extra.localRotation * (moveVelocity + _currentJumpVelocity) * Time.deltaTime);
                _currentJumpVelocity += Physics.gravity * Time.deltaTime;
            }

            if (_controller.isGrounded)
            {
                _isJumping = false;
            }
        }
        else
        {
            _controller.SimpleMove(extra.localRotation * moveVelocity);
        }

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift) && _controller.isGrounded)
        {
            _controller.SimpleMove(extra.localRotation * (moveVelocity * 3));
        }
    }
}