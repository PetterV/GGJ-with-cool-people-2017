using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarReceiver : MonoBehaviour {

	public string nameOfObject;
	public AudioClip soundOfObject;
	public GameObject mySign;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSonarHit()
    {
        Debug.Log( gameObject.name + "Play Sound " + "Do stuff" );
    	//For test purposes:
		this.GetComponent<PlaceholderTextDisplay>().SayMyName();
		//
		mySign.GetComponent<SpriteRenderer>().enabled = true;
		mySign.GetComponent<Sign>().isVisible = true;
		mySign.GetComponent<Sign>().duration = mySign.GetComponent<Sign>().startDuration;
	}
}
