using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using GrassGame;

public class PlaceStructures : MonoBehaviour { 
    private Vector2 spawnPos;
    private Vector2 templatePos;

    public GameObject BuildUIPanel;
    public GameObject PlaceCancelPanel;
    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    public bool validGridTile = false;
    
    void PlaceGround()
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
//                SpawnPosition spawnPos = Utils.GetMousePosition();
                Position pos = Utils.GetMousePosition();
                GameObject ScriptObject = GameObject.Find("ScriptObject");
                GroundClass groundScript = ScriptObject.GetComponent<GroundClass>();
                groundScript.CreateGround(pos);

        }
        validGridTile = false;
    }

    void PlaceFarm()
    {
        if (GridTracker.tileLocation[(int)templatePos.x, (int)templatePos.y] == 1)
        {
            FarmClass.CreateFarm(templatePos);
        }
    }

   void PlaceTownCenter()
    {
        if (GridTracker.tileLocation[(int)templatePos.x, (int)templatePos.y+1] == 1 && GridTracker.tileLocation[(int)templatePos.x+1, (int)templatePos.y+1] == 1 && GridTracker.tileLocation[(int)templatePos.x, (int)templatePos.y] == 1 && GridTracker.tileLocation[(int)templatePos.x+1, (int)templatePos.y] == 1)
        {
            TownCenterClass.CreateTownCenter(templatePos);
        }
    }
    
    public void DecisionMaker()
    {
        if (StructureBehaviour.gameStatus == "Beginning")
        {
            Position pos = Utils.GetMousePosition();
            spawnPos = new Vector2(pos.x, pos.y);
        }
        else
        {
            Position templatePosition = Utils.GetTemplatePosition();
            templatePos = new Vector2(templatePosition.x, templatePosition.y);
        }

        // Determine which structure to place
        if (PlacementScript.currentlySelectedObject == "GroundPlacer" && GridTracker.tileLocation[(int)templatePos.x, (int)templatePos.y] == 0 && GridTracker.GetEntityCount(Entities.GRASS) < StructureBehaviour.currentGroundLimit)
        {
            PlaceGround();
            Destroy(GameObject.Find(PlacementScript.currentlySelectedObject + "(Clone)"));
            PlacementScript.isAnObjectSelected = false;
        }
        else if (PlacementScript.currentlySelectedObject == "FarmPlacer" && GridTracker.tileLocation[(int)templatePos.x, (int)templatePos.y] == 1 && GridTracker.GetEntityCount(Entities.FARM) < StructureBehaviour.currentFarmLimit)
        {
            PlaceFarm();
            Destroy(GameObject.Find(PlacementScript.currentlySelectedObject + "(Clone)"));
            PlacementScript.isAnObjectSelected = false;
        }
        else if (PlacementScript.currentlySelectedObject == "TownCenterPlacer" && GridTracker.tileLocation[(int)templatePos.x, (int)templatePos.y+1] == 1 && GridTracker.GetEntityCount(Entities.TOWN_CENTER) < StructureBehaviour.currentTownCenterLimit)
        {
            PlaceTownCenter();
            Destroy(GameObject.Find(PlacementScript.currentlySelectedObject + "(Clone)"));
            PlacementScript.isAnObjectSelected = false;
        }
        else
        {
            // Nothing
        }
    }

}
