using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarReceiver : MonoBehaviour {

	public string nameOfObject;
	public AudioClip soundOfObject;
    private CircleDrawer visualizationCircle;

    public float distToCharacter = 0.0f;

	// Stuff dealing with the delay of sounds playing
	float soundDelayReductionFactor;
	float soundDelay = 0.0f;
	float maxSonarRange = 10.0f;
	float distanceReducer;
	float sonarTime;
	AudioSource audio;

	//Cooldown for Ray hit
	float cooldownTime = 0.5f;

    // Use this for initialization
    void Start () {
		this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        visualizationCircle = this.gameObject.GetComponentInChildren<CircleDrawer>();
		audio = this.gameObject.GetComponent<AudioSource>();
		audio.clip = soundOfObject;
		maxSonarRange = GameObject.Find("Character").GetComponent<Character>().sonarDist;
		sonarTime = GameObject.Find("SonarHandler").GetComponent<SonarHandler>().sonarTime;
	}	
	// Update is called once per frame
	void Update () {
		if (cooldownTime > 0)
			cooldownTime = cooldownTime - Time.deltaTime;
	}

    void OnSonarHit()
    {
		if ( cooldownTime < 0.01f){
	        Debug.Log( gameObject.name + "Play Sound " + "Do stuff" );
			soundDelayReductionFactor = distToCharacter/maxSonarRange;
			soundDelay = soundDelayReductionFactor * sonarTime;

			
			//if (!audio.isPlaying){
				audio.PlayDelayed(soundDelay);
				if (visualizationCircle)
					visualizationCircle.StartTimer(soundDelay);
		
			//}

			// If the object is an animal, fire it's animal effect!
			if (this.gameObject.tag == "Animal")
				this.gameObject.GetComponent<Animal>().AnimalHit();

			cooldownTime = 1.0f;

		}
    }
}
