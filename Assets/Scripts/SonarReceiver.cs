using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarReceiver : MonoBehaviour {

	public string nameOfObject;
	public AudioClip soundOfObject;
	public GameObject mySign;

    public float distToCharacter = 0.0f;

	// Stuff dealing with the delay of sounds playing
	public float soundDelayReductionFactor = 10;
	float soundDelay = 0.0f;
	float maxSonarRange = 10.0f;
	float distanceReducer;

    // Use this for initialization
    void Start () {
		this.gameObject.GetComponent<MeshRenderer>().enabled = false;	
		this.gameObject.GetComponent<AudioSource>().clip = soundOfObject;
		maxSonarRange = GameObject.Find("Character").GetComponent<Character>().sonarDist;
	}	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSonarHit()
    {
        Debug.Log( gameObject.name + "Play Sound " + "Do stuff" );
    	//For test purposes:
        if ( this.GetComponent<PlaceholderTextDisplay>() )
		    this.GetComponent<PlaceholderTextDisplay>().SayMyName();
		//
		distanceReducer = maxSonarRange * soundDelayReductionFactor;
		soundDelay = distToCharacter/distanceReducer;
		// Disabled because I'm trying to solve this with 3D sound settings:
		//this.gameObject.GetComponent<AudioSource>().volume = distToCharacter/maxSonarRange;
		this.gameObject.GetComponent<AudioSource>().PlayDelayed(soundDelay);
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(soundOfObject);
        if ( mySign )
        {
			mySign.GetComponent<SpriteRenderer>().enabled = true;
			mySign.GetComponent<Sign>().isVisible = true;
			mySign.GetComponent<Sign>().duration = mySign.GetComponent<Sign>().startDuration;
        }
    }
}
