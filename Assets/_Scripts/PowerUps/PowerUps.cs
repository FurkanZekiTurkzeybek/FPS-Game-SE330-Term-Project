using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    // Start is called before the first frame update
    void Start() { }


    public IEnumerator dashCoroutine() {
        float dashLength = 2;
        float duration = 1;
        // float distanceToMove = 2 * Time.deltaTime;

        for (float t = 0; t <= duration; t += Time.deltaTime) {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0; // Set Y component to zero
            // cameraForward.Normalize(); // Normalize the vector to ensure consistent speed
            Vector3 localMovement = transform.TransformDirection(cameraForward) * (dashLength * (10 * Time.deltaTime));

            transform.position += localMovement;

            yield return null;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Mouse1)) {
            StartCoroutine(dashCoroutine());
        }
    }
}