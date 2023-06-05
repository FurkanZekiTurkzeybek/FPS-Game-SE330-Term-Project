using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitUIScript : MonoBehaviour {
    public PlayerStats _playerStats;
    public GameObject hitCrossHair;

    private IEnumerator checkShot() {
        while (true) {
            if (_playerStats.getEnemyShot()) {
                hitCrossHair.SetActive(true);
                yield return new WaitForSeconds(1f);
                hitCrossHair.SetActive(false);
            }

            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(checkShot());
    }

    // Update is called once per frame
    void Update() {
        
    }
}