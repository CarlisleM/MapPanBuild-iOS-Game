using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlaceStructures : MonoBehaviour {

    private Vector2 spawnPos;
    
    public GameObject Panel;
    public GameObject Cancel_Place_Panel;
    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Place;
    public GameObject Cancel;

    void placeGround()
    {
        if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 0)
        {
            GroundClass.createGround(spawnPos);
            StructureBehaviour.currentMoney = StructureBehaviour.currentMoney - 25;
            PlacementScript.counter++;
        }
    }

    void placeFarm()
    {
        if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1)
        {
            Debug.Log(gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y]);
            FarmClass.createFarm(spawnPos);
            StructureBehaviour.currentMoney = StructureBehaviour.currentMoney - 100;
        }
    }

   void placeTownCenter()
    {
        if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1)
        {
            TownCenterClass.createTownCenter(spawnPos);
            StructureBehaviour.currentMoney = StructureBehaviour.currentMoney - 500;
        }
    }

    void destroyPlacer()
    {
        // Destroy template and return to the structure UI
        GameObject go = GameObject.Find(PlacementScript.currentlySelectedObject + "(Clone)"); // Find currently selected object
        if (go)
        {
            Destroy(go.gameObject); // Destroy currently selected object

            Button.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(true);
            Cancel_Place_Panel.SetActive(false);
        }
    }

    public void decisionMaker()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (StructureBehaviour.gameStatus == "Beginning")
        {
            spawnPos = new Vector2(Mathf.Round(worldPoint.x), Mathf.Round(worldPoint.y));
        }
        else
        {
            spawnPos = GameObject.Find(PlacementScript.currentlySelectedObject+"(Clone)").transform.position;
        }

        // Determine which structure to place
        if (PlacementScript.currentlySelectedObject == "GroundPlacer" && gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 0)
        {
            placeGround();
            destroyPlacer();
        }
        else if (PlacementScript.currentlySelectedObject == "FarmPlacer" && gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1)
        {
            placeFarm();
            destroyPlacer();
        }
        else if (PlacementScript.currentlySelectedObject == "TownCenterPlacer" && gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1)
        {
            placeTownCenter(); 
            destroyPlacer();
        }
        else
        {
            // Nothing
        }
    }

}
