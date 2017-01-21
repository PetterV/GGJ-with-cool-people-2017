using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarReceiver : MonoBehaviour {

	public string nameOfObject;
	public AudioClip soundOfObject;
	public GameObject mySign;

    public float distToCharacter = 0.0f;

    // Use this for initialization
    void Start () {
		this.gameObject.GetComponent<MeshRenderer>().enabled = false;	
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
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(soundOfObject);
		mySign.GetComponent<SpriteRenderer>().enabled = true;
		mySign.GetComponent<Sign>().isVisible = true;
		mySign.GetComponent<Sign>().duration = mySign.GetComponent<Sign>().startDuration;
	}
}
