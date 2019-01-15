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

    private Vector2 spawnPos;

    private bool isAnObjectSelected = false;
	public static string currentlySelectedObject;

    public void CreateGrass() {
		isAnObjectSelected = true;  // An object is selected
        GameObject go = GameObject.Find (currentlySelectedObject); // Find currently selected object
		if (go) {
			Destroy (go.gameObject); // Destroy currently selected object
		}
		currentlySelectedObject = "GrassTemplate(Clone)"; // Set new currently selected object
        spawnPos = new Vector2(6, 0);
        Instantiate(GrassTemplate, spawnPos, Quaternion.identity);
	}

	public void CreateBuilding1() {
		isAnObjectSelected = true;
		GameObject go = GameObject.Find (currentlySelectedObject);
		if (go) {
			Destroy (go.gameObject);
		}
		currentlySelectedObject = "HouseTemplate(Clone)";
        spawnPos = new Vector2(6, 0);
        Instantiate(HouseTemplate, spawnPos, Quaternion.identity);
    }

	public void CreateBuilding2() {
		isAnObjectSelected = true;
		GameObject go = GameObject.Find (currentlySelectedObject);
		if (go) {
			Destroy (go.gameObject);
		}
		currentlySelectedObject = "Building2Template(Clone)";
        Instantiate (Building2Template);
	}

}
