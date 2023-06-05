using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPackScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerStats>()) {
            Destroy(gameObject);
            other.gameObject.GetComponentInChildren<RifleScript>().addAmmo(10);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
