using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenController : MonoBehaviour {
    public void goToTestingAera() {
        SceneManager.LoadScene("TestingArea");
    }

    public void startTheGame() {
        SceneManager.LoadScene("LevelOne");
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}