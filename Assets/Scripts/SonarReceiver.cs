using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarReceiver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSonarHit()
    {
        Debug.Log( gameObject.name + "Play Sound " + "Do stuff" );
    }
}
