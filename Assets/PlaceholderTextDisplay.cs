using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderTextDisplay : MonoBehaviour {

	string textToDisplay;

	// Use this for initialization
	void Start () {
		textToDisplay = gameObject.GetComponent<SonarReceiver>().nameOfObject;
	}
	
	void SayMyName(){
		
	}
}
