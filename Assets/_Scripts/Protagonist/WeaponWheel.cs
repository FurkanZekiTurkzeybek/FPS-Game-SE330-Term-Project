using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWheel : MonoBehaviour {
    public GameObject playersRifle;
    public GameObject playersSword;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            playersRifle.SetActive(true);
            playersSword.SetActive(false);
        }

        else if (Input.GetKey(KeyCode.Alpha2)) {
            playersRifle.SetActive(false);
            playersSword.SetActive(true);
        }
    }
}