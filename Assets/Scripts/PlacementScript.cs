using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class PlacementScript : MonoBehaviour {

    [SerializeField]
    private GameObject Ground;
    [SerializeField]
    private GameObject GroundPlacer;
    [SerializeField]
    private GameObject FarmPlacer;
    [SerializeField]
    private GameObject TownCenterPlacer;

    public GameObject MainCamera;
    public GameObject StructureCamera;

    public GameObject Place;

    private Vector2 spawnPos;

    private bool isAnObjectSelected = false;
    public static string currentlySelectedObject;

    public static int counter = 0;

    public GameObject UndoButton;

    private Vector2 testSpawn;

    private void Start()
    {
        if (StructureBehaviour.gameStatus == "Beginning")
        {
            currentlySelectedObject = "GroundPlacer(Clone)";
        }
    }

    private void Update()
    {
        PlaceStructures myInstance = Place.GetComponent<PlaceStructures>();

        if (Input.GetMouseButtonDown(0) && counter < 20)
        {
            myInstance.decisionMaker();
        }

    }

    public void undo()
    {
        //if (PlaceStructures.groundInstances.Count > 0)
        //{
        //    Destroy(PlaceStructures.groundInstances[counter - 1]);
        //    PlaceStructures.groundInstances.Remove(PlaceStructures.groundInstances[PlacementScript.counter - 1]);
        //}

        if (counter > 0)
        {
            counter--;
        }
    }

    public void createGrass()
    {
        Debug.Log("Check 4");
        GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = false;
        // MainCamera.SetActive(false);
        // StructureCamera.SetActive(true);

        isAnObjectSelected = true;  // An object is selected
        GameObject go = GameObject.Find (currentlySelectedObject); // Find currently selected object
		if (go)
        {
			Destroy (go.gameObject); // Destroy currently selected object
		}
		currentlySelectedObject = "GroundPlacer(Clone)"; // Set new currently selected object
        spawnPos = new Vector2(6, 0);
        Instantiate(GroundPlacer, spawnPos, Quaternion.identity);
    }

	public void createFarm()
    {
        GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = false;
        isAnObjectSelected = true;
		GameObject go = GameObject.Find (currentlySelectedObject);
		if (go)
        {
			Destroy (go.gameObject);
		}
		currentlySelectedObject = "FarmPlacer(Clone)";
        spawnPos = new Vector2(6, 0);

        Instantiate(FarmPlacer, spawnPos, Quaternion.identity);

        // Cancel after placed

    }

	public void createTownCenter()
    {
		isAnObjectSelected = true;
		GameObject go = GameObject.Find (currentlySelectedObject);
		if (go)
        {
			Destroy (go.gameObject);
		}
		currentlySelectedObject = "TownCenterPlacer(Clone)";
        Instantiate (TownCenterPlacer);
	}
    
}


