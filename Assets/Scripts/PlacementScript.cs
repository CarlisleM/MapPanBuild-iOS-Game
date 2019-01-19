using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlacementScript : MonoBehaviour {

    [SerializeField]
    private GameObject Ground;
    [SerializeField]
	private GameObject GrassTemplate; 
	[SerializeField]
	private GameObject HouseTemplate;
	[SerializeField]
	private GameObject Building2Template;

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
            testSpawn = new Vector2(500, 500);
            GameObject initialTemplate = GameObject.Find("GrassTemplate(Clone)"); // Find currently selected object
            if (initialTemplate == null)
            {
                Debug.Log("Instantiated 3");
                Instantiate(GrassTemplate, testSpawn, Quaternion.identity); // Have to destroy this
            }
        }
    }

    private void Update()
    {
        TemplateScript myInstance = Place.GetComponent <TemplateScript> ();

        if (Input.GetMouseButtonDown(0) && counter < 20)
        {
         myInstance.placeGrass();        
        }
    }

    public void undo()
    {
        if (TemplateScript.groundInstances.Count > 0)
        {
            Destroy(TemplateScript.groundInstances[counter - 1]);
            TemplateScript.groundInstances.Remove(TemplateScript.groundInstances[PlacementScript.counter - 1]);
        }

        if (counter > 0)
        {
            counter--;
            
        }
    }
    
    public void createGrass()
    {
        GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = false;
        // MainCamera.SetActive(false);
        // StructureCamera.SetActive(true);

        isAnObjectSelected = true;  // An object is selected
        GameObject go = GameObject.Find (currentlySelectedObject); // Find currently selected object
		if (go)
        {
			Destroy (go.gameObject); // Destroy currently selected object
		}
		currentlySelectedObject = "GrassTemplate(Clone)"; // Set new currently selected object
        spawnPos = new Vector2(6, 0);
        Debug.Log("Instantiated 2");
        Instantiate(GrassTemplate, spawnPos, Quaternion.identity);
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
		currentlySelectedObject = "HouseTemplate(Clone)";
        spawnPos = new Vector2(6, 0);

        Instantiate(HouseTemplate, spawnPos, Quaternion.identity);

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
		currentlySelectedObject = "Building2Template(Clone)";
        Instantiate (Building2Template);
	}
    
}


