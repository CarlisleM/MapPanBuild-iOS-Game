﻿using System.Collections;
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

    public static bool isAnObjectSelected = false;
    public static string currentlySelectedObject;

    public GameObject UndoButton;

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

            if (Input.GetMouseButtonDown(0) && GroundClass.groundCount < 20)
            {
                myInstance.decisionMaker();
            }
        }
    }

    public void undo()
    {
        if (GroundClass.groundCount > 0)
        {
            GameObject ScriptObject = GameObject.Find("ScriptObject");
            GroundClass groundScript = ScriptObject.GetComponent<GroundClass>();
            groundScript.createGround(spawnPos);
            Destroy(GroundClass.groundTileList[GroundClass.groundCount-1]);
            GroundClass.groundTileList.RemoveAt(GroundClass.groundCount-1);
            GroundClass.groundCount--;
        }
    }

    public void createGround()
    {
        isAnObjectSelected = true;  // An object is selected

        GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = false;
        // MainCamera.SetActive(false);
        // StructureCamera.SetActive(true);
        
        GameObject go = GameObject.Find (currentlySelectedObject); // Find currently selected object
		if (go)
        {
			Destroy (go.gameObject); // Destroy currently selected object
		}

        currentlySelectedObject = "GroundPlacer"; // Set new currently selected object
        spawnPos = new Vector2(9, 6);
        Instantiate(Resources.Load(currentlySelectedObject), spawnPos, Quaternion.identity);
    }

	public void createFarm()
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

	public void createTownCenter()
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
