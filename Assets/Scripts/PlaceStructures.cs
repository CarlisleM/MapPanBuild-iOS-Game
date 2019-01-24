using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlaceStructures : MonoBehaviour {

    private Vector2 spawnPos;

    public GameObject PlacementManager;
    public GameObject Panel;
    public GameObject Cancel_Place_Panel;
    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Place;
    public GameObject Cancel;

    public string valid = "Not joined";
    
    void placeGround()
    {
        Debug.Log("x is: " + spawnPos.x + " y is: " + spawnPos.y);
        // Check if there is a ground tile next to it
        if (spawnPos.x > 0 && spawnPos.x < 9)
        {
            // Not against Left or right border
            if (spawnPos.y > 0 && spawnPos.y < 9)
            {
                // Not against left, right, top or bottom boundary
                if (gridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] == 1 || gridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] == 1 || gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] == 1 || gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] == 1)
                {
                    // Not against any boundaries
                    Debug.Log("Not against any boundaries");
                    valid = "joined";
                }
            }
            else
            {
                if (spawnPos.y == 0)
                {
                    if (gridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] == 1 || gridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] == 1 || gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] == 1)
                    {
                        // Bottom boundary
                        Debug.Log("Bottom boundary");
                        valid = "joined";
                    }
                }
                else
                {
                    if (gridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] == 1 || gridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] == 1 || gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] == 1)
                    {
                        // Top boundary
                        Debug.Log("Top boundary");
                        valid = "joined";
                    }
                }
            }
        }
        else
        {
            // Against left or right boundary and against the top or bottom boundary
            if (spawnPos.x == 0)
            {
                if (spawnPos.y == 0)
                {
                    if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] == 1 || gridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y+1] == 1 || gridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] == 1)
                    {
                        // Bottom left corner
                        Debug.Log("Bottom left corner");
                        valid = "joined";
                    }
                }
                else if (spawnPos.y == 9)
                {
                    if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] == 1 || gridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y-1] == 1 || gridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] == 1)
                    {
                        // Top left corner
                        Debug.Log("Top left corner");
                        valid = "joined";
                    }
                }
                else
                {
                    if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] == 1 || gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] == 1 || gridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] == 1)
                    {
                        // Left boundary
                        Debug.Log("Left boundary");
                        valid = "joined";
                    }
                }
            }
            else
            {
                if (spawnPos.y == 0)
                {
                    if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] == 1 || gridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y+1] == 1 || gridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] == 1)
                    {
                        // Bottom right corner
                        Debug.Log("Bottom right corner");
                        valid = "joined";
                    }
                }
                else if (spawnPos.y == 9)
                {
                    if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] == 1 || gridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y-1] == 1 || gridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] == 1)
                    {
                        // Top right corner
                        Debug.Log("Top right corner");
                        valid = "joined";
                    }
                }
                else
                {
                    if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] == 1 || gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] == 1 || gridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] == 1)
                    {
                        // Right boundary
                        Debug.Log("Right boundary");
                        valid = "joined";
                    }
                }
            }
        }

        if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 0 && valid == "joined")
        {
            GameObject ScriptObject = GameObject.Find("ScriptObject");
            GroundClass groundScript = ScriptObject.GetComponent<GroundClass>();
            groundScript.createGround(spawnPos);
        }

        valid = "Not joined";
    }

    void placeFarm()
    {
        if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1)
        {
            FarmClass.createFarm(spawnPos);
        }
    }

   void placeTownCenter()
    {
        if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1)
        {
            TownCenterClass.createTownCenter(spawnPos);
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

    //StructureBehaviour.level1.Farm_limit
    public int i = 1;

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
        if (PlacementScript.currentlySelectedObject == "GroundPlacer" && gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 0 && GroundClass.groundCount < StructureBehaviour.currentGroundLimit)
        {
            placeGround();
            destroyPlacer();
            PlacementScript.isAnObjectSelected = false;
        }
        else if (PlacementScript.currentlySelectedObject == "FarmPlacer" && gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1 && FarmClass.farmCount < StructureBehaviour.currentFarmLimit)
        {
            placeFarm();
            destroyPlacer();
            PlacementScript.isAnObjectSelected = false;
        }
        else if (PlacementScript.currentlySelectedObject == "TownCenterPlacer" && gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1 && TownCenterClass.townCenterCount < StructureBehaviour.currentTownCenterLimit)
        {
            placeTownCenter(); 
            destroyPlacer();
            PlacementScript.isAnObjectSelected = false;
        }
        else
        {
            // Nothing
        }
    }

}
