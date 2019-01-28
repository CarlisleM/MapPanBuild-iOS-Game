using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using GrassGame;

public class PlacementScript : MonoBehaviour {

    public GameObject Place;

    private Vector2 spawnPos;

    public static bool isAnObjectSelected = false;
    public static string currentlySelectedObject;

    private void Start()
    {
        if (StructureBehaviour.gameStatus == "Beginning")
        {
            currentlySelectedObject = "GroundPlacer";
        }
    }

    private void Update()
    {
        if (StructureBehaviour.gameStatus == "Beginning")
        {
            PlaceStructures myInstance = Place.GetComponent<PlaceStructures>();

            if (Input.GetMouseButtonDown(0) && GridTracker.GetEntityCount(Entities.GRASS) < 20)
            {

                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    myInstance.DecisionMaker();
                }
            }
        }
    }

    public void Undo()
    {
        GridTracker.Undo();
    }

    public void CreateGround()
    {
        isAnObjectSelected = true;  // An object is selected

        GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = false;

        GameObject go = GameObject.Find (currentlySelectedObject); // Find currently selected object
		if (go)
        {
			Destroy (go.gameObject); // Destroy currently selected object
		}

        currentlySelectedObject = "GroundPlacer"; // Set new currently selected object
        spawnPos = new Vector2(9, 6);
        Instantiate(Resources.Load(currentlySelectedObject), spawnPos, Quaternion.identity);
    }

	public void CreateFarm()
    {
        isAnObjectSelected = true;

        GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = false;
        
		GameObject go = GameObject.Find (currentlySelectedObject);
		if (go)
        {
			Destroy (go.gameObject);
		}

        currentlySelectedObject = "FarmPlacer";
        spawnPos = new Vector2(9, 6);
        Instantiate(Resources.Load(currentlySelectedObject), spawnPos, Quaternion.identity);
    }

	public void CreateTownCenter()
    {
		isAnObjectSelected = true;

        GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = false;

        GameObject go = GameObject.Find (currentlySelectedObject);
		if (go)
        {
			Destroy (go.gameObject);
		}

		currentlySelectedObject = "TownCenterPlacer";
        spawnPos = new Vector2(9.5f, 6.5f);
        Instantiate(Resources.Load(currentlySelectedObject), spawnPos, Quaternion.identity);
    }    
}
