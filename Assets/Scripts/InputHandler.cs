using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public Character character;
	public bool movementOn = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( movementOn ){
	        character.turnAxisInput = Input.GetAxis( "Horizontal" );

            if( Input.GetButtonDown( "SonarButton" ) )
            {
                character.BigSonarPulse();
            }
            if( Input.GetButtonDown( "SmallSonar" ) )
            {
                character.SmallSonarPulse();
            }
        }
		if (Input.GetKey("escape"))
			Application.Quit();
    }
}
