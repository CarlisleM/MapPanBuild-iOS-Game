using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using GrassGame;

public class PlaceStructures : MonoBehaviour { 
    private Vector2 spawnPos;
    
    public GameObject Cancel_Place_Panel;
    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Place;
    public GameObject Cancel;

    public bool validGridTile = false;
    
    void placeGround()
    {
        // Check if there is a ground tile next to it
        if (spawnPos.x > 0 && spawnPos.x < 9)
        {
            // Not against Left or right border
            if (spawnPos.y > 0 && spawnPos.y < 9)
            {
                if (GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] >= 1 || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] >= 1 || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] >= 1)
                {
                    validGridTile = true;   // Not against any boundaries
                }
            }
            else
            {
                if (spawnPos.y == 0)
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] >= 1 || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] >= 1 || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] >= 1)
                    {
                        validGridTile = true;   // Bottom boundary
                    }
                }
                else
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] >= 1 || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] >= 1 || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] >= 1)
                    {
                        validGridTile = true;   // Top boundary
                    }
                }
            }
        }
        else
        {
            // Against left or right
            if (spawnPos.x == 0)
            {
                if (spawnPos.y == 0)
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y+1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] >= 1)
                    {
                        
                        validGridTile = true;   // Bottom left corner
                    }
                }
                else if (spawnPos.y == 9)
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y-1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] >= 1)
                    {
                        
                        validGridTile = true;   // Top left corner
                    }
                }
                else
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] >= 1)
                    {
                        validGridTile = true;   // Left boundary
                    }
                }
            }
            else
            {
                if (spawnPos.y == 0)
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y+1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] >= 1)
                    {
                        validGridTile = true;   // Bottom right corner
                    }
                }
                else if (spawnPos.y == 9)
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y-1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] >= 1)
                    {
                        validGridTile = true;   // Top right corner
                    }
                }
                else
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] >= 1 || GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] >= 1)
                    {
                        validGridTile = true;   // Right boundary
                    }
                }
            }
        }

        if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 0 && validGridTile == true)
        {
                Position pos = Utils.GetPosition();
                GameObject ScriptObject = GameObject.Find("ScriptObject");
                GroundClass groundScript = ScriptObject.GetComponent<GroundClass>();
                groundScript.CreateGround(pos);

        }
        validGridTile = false;
    }

    void placeFarm()
    {
        if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1)
        {
            FarmClass.createFarm(spawnPos);
        }
    }

   void placeTownCenter()
    {
        if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] == 1 && GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y+1] == 1 && GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1 && GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] == 1)
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

            // Check if these are needed
            Button.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(true);
            Cancel_Place_Panel.SetActive(false);
        }
    }
    
    public void decisionMaker()
    {
        Position pos = Utils.GetPosition();

        if (StructureBehaviour.gameStatus == "Beginning")
        {
            spawnPos = new Vector2(pos.x, pos.y);
        }
        else
        {
            spawnPos = GameObject.Find(PlacementScript.currentlySelectedObject+"(Clone)").transform.position;
        }

        // Determine which structure to place
        if (PlacementScript.currentlySelectedObject == "GroundPlacer" && GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 0 && GroundClass.groundCount < StructureBehaviour.currentGroundLimit)
        {
            placeGround();
            destroyPlacer();
            PlacementScript.isAnObjectSelected = false;
        }
        else if (PlacementScript.currentlySelectedObject == "FarmPlacer" && GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1 && FarmClass.farmCount < StructureBehaviour.currentFarmLimit)
        {
            placeFarm();
            destroyPlacer();
            PlacementScript.isAnObjectSelected = false;
        }
        else if (PlacementScript.currentlySelectedObject == "TownCenterPlacer" && GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] == 1 && TownCenterClass.townCenterCount < StructureBehaviour.currentTownCenterLimit)
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
