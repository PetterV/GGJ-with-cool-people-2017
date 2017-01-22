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
    [HideInInspector]
    public Vector3 hitpos;
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
	       // Debug.Log( gameObject.name + "Play Sound " + "Do stuff" );
			soundDelayReductionFactor = distToCharacter/maxSonarRange;
			soundDelay = soundDelayReductionFactor * sonarTime;

			
			//if (!audio.isPlaying){
				audio.PlayDelayed(soundDelay);
            if (visualizationCircle)
            {
                visualizationCircle.startAlpha = 1 - soundDelayReductionFactor;
                //Debug.Log(visualizationCircle.startAlpha);
                visualizationCircle.StartTimer(soundDelay);
            }
            visualizationCircle.transform.position = hitpos;
            Debug.Log( distToCharacter );

            //}

            // If the object is an animal, fire it's animal effect!
            if (this.gameObject.tag == "Animal")
				this.gameObject.GetComponent<Animal>().AnimalHit();

			cooldownTime = 1.0f;

		}
    }
}
