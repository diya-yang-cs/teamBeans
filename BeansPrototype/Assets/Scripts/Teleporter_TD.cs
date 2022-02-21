using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter_TD : MonoBehaviour {

    public GameObject tp1, tp2;
    
    void Start() {
        tp1 = this.gameObject;
    }

    void OnTriggerStay2D (Collider2D trig) {
        if (Input.GetButtonDown ("Submit")) {
            trig.gameObject.transform.position = tp2.gameObject.transform.position;
            
        }
        
    }

   
}
