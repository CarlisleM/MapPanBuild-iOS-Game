using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlacementScript : MonoBehaviour {
	
	[SerializeField]
	private GameObject GrassTemplate; 
	[SerializeField]
	private GameObject HouseTemplate;
	[SerializeField]
	private GameObject Building2Template;

	private bool isAnObjectSelected = false;
	public static string currentlySelectedObject;

    public void CreateGrass() {
		transform.position = new Vector2(6,0);
		isAnObjectSelected = true;	// An object is selected
		GameObject go = GameObject.Find (currentlySelectedObject); // Find currently selected object
		if (go) {
			Destroy (go.gameObject); // Destroy currently selected object
		}
		currentlySelectedObject = "GrassTemplate(Clone)"; // Set new currently selected object
		isAnObjectSelected = true;	// An object is selected
		Instantiate(GrassTemplate, transform.position, Quaternion.identity);
		//		Instantiate (GrassTemplate); // Instantiate newly selected object
	}

	public void CreateBuilding1() {
		isAnObjectSelected = true;
		GameObject go = GameObject.Find (currentlySelectedObject);
		if (go) {
			Destroy (go.gameObject);
		}
		currentlySelectedObject = "HouseTemplate(Clone)";
		isAnObjectSelected = true;
		Instantiate (HouseTemplate);
	}

	public void CreateBuilding2() {
		isAnObjectSelected = true;
		GameObject go = GameObject.Find (currentlySelectedObject);
		if (go) {
			Destroy (go.gameObject);
		}
		currentlySelectedObject = "Building2Template(Clone)";
		isAnObjectSelected = true;
		Instantiate (Building2Template);
	}

}

