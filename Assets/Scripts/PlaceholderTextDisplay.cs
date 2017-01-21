using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderTextDisplay : MonoBehaviour {

	//string textToDisplay;
    Transform target;
    private LineRenderer parentCircle;

	// Use this for initialization
	void Start () {
		//textToDisplay = gameObject.GetComponent<SonarReceiver>().nameOfObject;
        target = GameObject.Find("Character").transform;
        parentCircle = gameObject.GetComponentInParent<LineRenderer>();
    }

    private void Update()
    {
        if(target != null)
		{
            //transform.LookAt(target);
            //transform.Rotate(0, 180, 0);
            transform.rotation = target.rotation;
        }
        this.gameObject.GetComponent<TextMesh>().color = parentCircle.startColor;
    }
}
