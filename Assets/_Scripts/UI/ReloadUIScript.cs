using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReloadUIScript : MonoBehaviour {
    public RifleScript rifleScript;
    private TextMeshProUGUI _reloadIndicator;
    
    // Start is called before the first frame update
    private IEnumerator indicateReload() {
        while (true) {
            if (rifleScript.getReloadBool()) {
                _reloadIndicator.text = "Press R to reload";
            }
            else if (rifleScript.getOutOfAmmo()) {
                _reloadIndicator.text = "Out of ammo";
            }
            else {
                _reloadIndicator.text = "";
            }
            yield return null;
        }
    }

    void Start() {
        _reloadIndicator = gameObject.GetComponent<TextMeshProUGUI>();
        _reloadIndicator.color = Color.black;
        StartCoroutine(indicateReload());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
