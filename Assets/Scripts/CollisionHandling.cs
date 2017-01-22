using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandling : MonoBehaviour {
	
	public bool willReset = false;
	public AudioClip[] crashSounds;

	void OnTriggerEnter (Collider obstacle){
		if (willReset == false && obstacle.gameObject.tag != "Animal"){
			Debug.Log("I collided! thing hit is: " + obstacle.gameObject.name);
			willReset = true;
			int random = Random.Range(0, 3);
			this.gameObject.GetComponent<AudioSource>().clip = crashSounds[random];
			float randomPitch = Random.Range(0.7f,1.2f);
			this.gameObject.GetComponent<AudioSource>().pitch = randomPitch;
			this.gameObject.GetComponent<AudioSource>().Play();
			GameObject.Find("Character").GetComponent<Character>().moveSpeed = 0;
			GameObject.Find("GameManager").GetComponent<InputHandler>().movementOn = false;
		}
	}
	// Update is called once per frame
	void Update () {
		if ( willReset ){
			if( Input.GetButtonDown( "SonarButton" ) )
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
}
