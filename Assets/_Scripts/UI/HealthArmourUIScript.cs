using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthArmourUIScript : MonoBehaviour {
    public PlayerStats statsScript;
    private TextMeshProUGUI _healthLevel;
    
    // Start is called before the first frame update
    void Start() {
        _healthLevel = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       _healthLevel.text =  "Health: "+ statsScript.getHealth()+"\n"+"Armour: "+ statsScript.getArmour();
    }
}
