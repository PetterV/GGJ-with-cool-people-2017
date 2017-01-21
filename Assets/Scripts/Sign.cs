using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {

	public float startDuration = 3.0f;
	public float duration;
	Transform target;
	public bool isVisible = false;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Character").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null)
		{
			transform.LookAt(target);
		}
		if (isVisible == true){
			duration = duration - Time.deltaTime;
            Color color = this.gameObject.GetComponent<SpriteRenderer>().color;
			color.a = duration / startDuration;
            this.gameObject.GetComponent<SpriteRenderer>().color = color;
            if ( duration < 0 ){
				this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				isVisible = false;
				color.a = duration / startDuration;
                this.gameObject.GetComponent<SpriteRenderer>().color = color;
            }
		}
	}
}
