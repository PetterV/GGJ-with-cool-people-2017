using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampaignManager : MonoBehaviour {

	public int currentCampaignTargetOrder = 0;
	int isWaitingToChangeTo = 1;
	GameObject animalText;

	// Use this for initialization
	void Start () {
		animalText = GameObject.FindWithTag("AnimalTextBox");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCampaignTargetOrder == 1 && isWaitingToChangeTo == 1){
			isWaitingToChangeTo = isWaitingToChangeTo + 1;
			animalText.GetComponent<Text>().text = "Seek out the next animal!";
		}
	}
}
