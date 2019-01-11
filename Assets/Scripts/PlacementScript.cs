using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementScript : MonoBehaviour {

	private int selectedObjectInArray;
	private GameObject currentlySelectedObject;

	[SerializeField]
	private GameObject[] selectableObjects;

	private bool isAnObjectSelected = false;

	// Use this for initialization
	void Start () {
		selectedObjectInArray = 0; // Start with element 0 grass template
	}
	
	// Update is called once per frame
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

		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && isAnObjectSelected == true) {
			selectedObjectInArray++;

			if (selectedObjectInArray > selectableObjects.Length - 1) {
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
