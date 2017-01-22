using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampaignManager : MonoBehaviour {

	public int currentCampaignTargetOrder = 0;
	int isWaitingToChangeTo = 0;
	GameObject animalText;
	public float messageDuration = 6.0f;
	float changeTimer = 0f;

	// Use this for initialization
	void Start () {
		animalText = GameObject.FindWithTag("AnimalTextBox");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCampaignTargetOrder == isWaitingToChangeTo){
			changeTimer = changeTimer + Time.deltaTime;
		}

		if (currentCampaignTargetOrder == 0 && isWaitingToChangeTo == 0){

			//Notification about completion of this stage
			if (changeTimer > 4.0f){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the RUSTLE IN THE LEAVES by the DEAD TREES";
				isWaitingToChangeTo = currentCampaignTargetOrder + 1;
				changeTimer = 0f;
			}
		}


		if (currentCampaignTargetOrder == 1 && isWaitingToChangeTo == 1){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The RUSTLING IN THE LEAVES understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the PROWLING CAT by the ABANDONED FARM";
				isWaitingToChangeTo = currentCampaignTargetOrder + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 2 && isWaitingToChangeTo == 2){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The PROWLING CAT understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the FERAL CAT by the ABANDONED FARM";
				isWaitingToChangeTo = currentCampaignTargetOrder + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 3 && isWaitingToChangeTo == 3){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The FERAL CAT understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the DEFINITE SNAKE by the STAGNANT POND";
				isWaitingToChangeTo = currentCampaignTargetOrder + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 4 && isWaitingToChangeTo == 4){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The DEFINITE SNAKE understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the FOOL BIRD by the DENSE FOREST";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 5 && isWaitingToChangeTo == 5){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The FOOL BIRD understands a little now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the ELDER ELK by the MOUNTAINSIDE";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 6 && isWaitingToChangeTo == 6){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The ELDER ELK understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the LESS SENIOR ELK in the CLEARING";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 7 && isWaitingToChangeTo == 7){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The LESS SENIOR ELK understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the OWL by the DENSE FOREST";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 8 && isWaitingToChangeTo == 8){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The OWL, in its infinite wisdom, understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the TOAD by the OVERGROWN WELL";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 9 && isWaitingToChangeTo == 9){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The TOAD understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the FROG by the STAGNANT POND";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 10 && isWaitingToChangeTo == 10){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The FROG understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the FOX UNSAID by the STONE RUINS";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 11 && isWaitingToChangeTo == 11){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The FOX UNSAID understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the TWO MICE by the DEAD TREES";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 12 && isWaitingToChangeTo == 12){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The TWO MICE understand now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the PROBABLY BADGER by the CLEARING";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 13 && isWaitingToChangeTo == 13){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The PROBABLY BADGER understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the SWARM OF AMENABLE BEES by the MOUNTAINSIDE";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 14 && isWaitingToChangeTo == 14){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The SWARM OF AMENABLE BEES understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Seek the OTHER BAT by the STREAM";
				isWaitingToChangeTo = isWaitingToChangeTo + 1;
				changeTimer = 0f;
			}
		}

		if (currentCampaignTargetOrder == 15 && isWaitingToChangeTo == 15){

			//Notification about completion of this stage
			animalText.GetComponent<Text>().text = "The OTHER BAT understands now.";
			if (changeTimer > messageDuration){
				//Descriptiong of next target
				animalText.GetComponent<Text>().text = "Your JOURNEY is at an end.\nFifth Wave Feminism rules the land.\nIt is time to look to new horizons.\n\nClick \"Replay\" for Sixth Wave Feminism gameplay.";
			}
		}
	}
}