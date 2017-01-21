using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {

	public int feminismCount = 0;
	public int feminismTargetValue = 0;
	public int myCampaignTargetOrder = 0;
	int currentTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AnimalHit ()
	{
		currentTarget = GameObject.Find("GameManager").GetComponent<CampaignManager>().currentCampaignTargetOrder;
		if ( myCampaignTargetOrder < currentTarget){
			//Give real target message
		}
		else if ( myCampaignTargetOrder == currentTarget){
			feminismCount = feminismCount + 1;
		}
		else if ( myCampaignTargetOrder > currentTarget){
			//Give real target message
		}

		if (feminismCount >= feminismTargetValue){
			//Add success display etc. here!
			if (myCampaignTargetOrder == currentTarget){
				GameObject.Find("GameManager").GetComponent<CampaignManager>().currentCampaignTargetOrder = currentTarget + 1;
			}
		} 
	}
}
