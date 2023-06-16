using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerControllerScript : MonoBehaviour {
    private SpawnerScript[] _spawners;

    public Transform armourPack;
    public Transform bulletPack;
    public Transform grenadePack;
    public Transform rocketPack;
    public Transform medkit;

    // public Transform meleeEnemy;
    // public Transform rangedEnemy;
    // private int meleeEnemyCount = 0;
    // private int rangedEnemyCount = 0;

    private int armourPackCount = 0;
    private int bulletPackCount = 0;
    private int grenadePackCount = 0;
    private int rocketPackCount = 0;
    private int medkitCount = 0;

    private List<Transform> _spawnOrder;


    private IEnumerator controller() {
        for (int i = 0; i < _spawners.Length; i++) {
            if (i == _spawners.Length - 1) {
                i = 0;
            }

            yield return new WaitForSeconds(5f);
        }
    }

    private void spawn(int indexNo) {
        _spawners[indexNo].gameObject.GetComponent<SpawnerScript>().instantiate(armourPack);
    }

    // Start is called before the first frame update
    void Start() {
        _spawners = gameObject.GetComponentsInChildren<SpawnerScript>();
        // _spawnOrder.Add(armourPack);
        // _spawnOrder.Add(bulletPack);
        // _spawnOrder.Add(grenadePack);
        // _spawnOrder.Add(rocketPack);
        // _spawnOrder.Add(medkit);
    }

    // Update is called once per frame
    void Update() { }
}