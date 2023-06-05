using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float _mouseX;

    private float _mouseY;

    private float _minimumY = -60F;

    private float _maximumY = 60F;

    public Transform character;
    
    private
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX += 5 * Input.GetAxis("Mouse X");
        _mouseY -= 5 * Input.GetAxis("Mouse Y");
        _mouseY = Mathf.Clamp(_mouseY, _minimumY, _maximumY);

        transform.localRotation = Quaternion.Euler(_mouseY, _mouseX, 0);
        
        character.localRotation = Quaternion.Euler(0,_mouseX,0);
    }
}
