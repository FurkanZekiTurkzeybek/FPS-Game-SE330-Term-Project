using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWheel : MonoBehaviour {
    public GameObject playersRifle;
    public GameObject playersSword;
    public GameObject playersRPG;
    public GameObject playersGrenade;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            playersRifle.SetActive(true);
            playersSword.SetActive(false);
            playersRPG.SetActive(false);
            playersGrenade.SetActive(false);
        }

        else if (Input.GetKey(KeyCode.Alpha2)) {
            playersRifle.SetActive(false);
            playersSword.SetActive(true);
            playersRPG.SetActive(false);
            playersGrenade.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.Alpha3)) {
            playersRifle.SetActive(false);
            playersSword.SetActive(false);
            playersRPG.SetActive(true);
            playersGrenade.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.G)) {
            playersRifle.SetActive(false);
            playersSword.SetActive(false);
            playersRPG.SetActive(false);
            playersGrenade.SetActive(true);
        }
    }
}