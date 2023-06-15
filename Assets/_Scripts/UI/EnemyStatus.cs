using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {
    public PlayerStats playerStats;
    private TextMeshProUGUI _enemyKillCount;

    // Start is called before the first frame update
    void Start() {
        _enemyKillCount = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        _enemyKillCount.text = $"{playerStats.getKillCount()} / {playerStats.getRequieredKillCount()}";
    }
}