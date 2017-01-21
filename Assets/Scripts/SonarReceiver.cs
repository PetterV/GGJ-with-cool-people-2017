using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarReceiver : MonoBehaviour {

	public string nameOfObject;
	public AudioClip soundOfObject;

    public float distToCharacter = 0.0f;

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

	}
}
