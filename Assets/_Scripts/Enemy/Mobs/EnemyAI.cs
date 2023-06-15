using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    protected Transform playerLocation;
    private bool _playerDetected;
    protected float _enemyVelocity = 1;
    protected bool _isAttacking;


    // Start is called before the first frame update

    protected virtual void Start() {
        StartCoroutine(patrol(180));
        playerLocation = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame

    void Update() { }

    public void setDetected() { //this method is to get the aggro of the enemy when its shot during patrol.
        //set the _playerDetected bool to true when the enemy is get shot.
        //DO not implement this yet. You need to think of the range arrangement carefully add it at the later stages.
    }

    //patrolling and following methods
    private IEnumerator patrol(float yAxis) {
        if (_playerDetected == false) {
            for (float distanceSoFar = 0; distanceSoFar < 4; distanceSoFar += 2 * Time.deltaTime) {
                transform.Translate(Vector3.forward * (_enemyVelocity * Time.deltaTime));
                yield return null;
            }
        }

        if (Vector3.Distance(transform.position, playerLocation.position) <= 5) {
            yield return StartCoroutine(followPlayer()); //switching to combat mode
        }
        else {
            transform.Rotate(0, yAxis, 0);
            yield return StartCoroutine(patrol(-yAxis));
        }
    }

    private IEnumerator followPlayer() {
        while (true) {
            Vector3 newDirection = new Vector3(playerLocation.position.x, transform.position.y,
                playerLocation.position.z);
            transform.LookAt(newDirection);

            transform.position += transform.forward * (_enemyVelocity * Time.deltaTime);

            if (Vector3.Distance(transform.position, playerLocation.position) >= 10) {
                yield return StartCoroutine(patrol(180)); // switching to patrol mode
            }

            combat();

            yield return null;
        }
    }


    protected virtual void combat() { }
}