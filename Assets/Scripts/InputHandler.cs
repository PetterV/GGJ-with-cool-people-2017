using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public Character character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        character.turnAxisInput = Input.GetAxis( "Horizontal" );

        if( Input.GetButtonDown( "AButton" ) )
        {
            character.SonarPulse();
        }
    }
}
