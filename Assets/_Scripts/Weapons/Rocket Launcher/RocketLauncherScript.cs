using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RocketLauncherScript : RifleScript {
    private Rigidbody _prefabrocket;

    protected override IEnumerator fire() {
        while (true) {
            if (Input.GetKey(KeyCode.Mouse0)) {
                Debug.Log($"{GetType().Name}: Rocket is fired");
                shoot();
                yield return new WaitForSeconds(1f);
            }

            yield return null;
        }
    }

    protected override void shoot() {
        _prefabrocket = Instantiate(bullet, transform.position, transform.rotation);
        _prefabrocket.velocity = transform.forward * _bulletSpeed;
    }

    // Start is called before the first frame update
    void Start() { }

    protected void OnEnable() {
        _bulletSpeed = 20f;
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update() { }
}