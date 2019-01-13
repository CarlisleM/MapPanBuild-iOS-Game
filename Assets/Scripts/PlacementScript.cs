using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlacementScript : MonoBehaviour {

	private int selectedObjectInArray;
	private GameObject currentlySelectedObject;

	[SerializeField] // Can remove this for final production and set the tier level manually
	private int currentTier = 1;

	[SerializeField]
	private GameObject[] selectableObjects;

	private bool isAnObjectSelected = false;

	// Use this for initialization
	void Start () {
		selectedObjectInArray = 0; // Start with element 0 grass template
	}
				
	// Update i s called once per frame
	void Update () {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 spawnPos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

		// e selects an object
		if (Input.GetKeyDown ("e") && isAnObjectSelected == false) {
			currentlySelectedObject = (GameObject)Instantiate (selectableObjects [selectedObjectInArray], spawnPos, Quaternion.identity);
			isAnObjectSelected = true;
		}

		// Right click deselects object
		if (Input.GetMouseButtonDown (1) && isAnObjectSelected == true) {
			Destroy (currentlySelectedObject);
			isAnObjectSelected = false;
			selectedObjectInArray = 0;
		}


		if (currentTier == 1) {
	//		selectableObjects = 1;
	//		Debug.Log (selectableObjects);

			// Starter building and a farm
		} else if (currentTier == 2) {
			// Extra building Tier 2
		} else if (currentTier == 3) {
			// Extra building Tier 3
		} else if (currentTier == 4) {
			// Extra building Tier 4
		} else {
			// Extra building Tier 5
		}



		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && isAnObjectSelected == true) {
			selectedObjectInArray++;

			Debug.Log (selectableObjects.Length);
			Debug.Log (selectedObjectInArray);

			if (selectedObjectInArray > currentTier) {
				selectedObjectInArray = 0;
			}

			Destroy (currentlySelectedObject);
			currentlySelectedObject = (GameObject)Instantiate (selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
		} else if (Input.GetAxis("Mouse ScrollWheel") < 0 && isAnObjectSelected == true) {
				selectedObjectInArray--;

				if (selectedObjectInArray < 0) {
					selectedObjectInArray = selectableObjects.Length - 1;
				}

				Destroy (currentlySelectedObject);
				currentlySelectedObject = (GameObject)Instantiate(selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
		}

	}
}
