using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using GrassGame;

public class PlaceStructures : MonoBehaviour { 
    private Vector2 spawnPos;

    public GameObject BuildUIPanel;
    public GameObject PlaceCancelPanel;
    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    int xGridMax = GridTracker.tileLocation.GetLength(0)-1;
    int xGridMin = 0;
    int yGridMax = GridTracker.tileLocation.GetLength(1)-1;
    int yGridMin = 0;

    public bool validGridTile = false;
    
    void PlaceGround()
    {
        // Check if there is a ground tile next to it
        if (spawnPos.x > xGridMin && spawnPos.x < xGridMax)
        {
            // Not against Left or right border
            if (spawnPos.y > yGridMin && spawnPos.y < yGridMax)
            {
                if (GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] != (int)Entities.EMPTY)
                {
                    validGridTile = true;   // Not against any boundaries
                }
            }
            else
            {
                if (spawnPos.y == yGridMin)
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] != (int)Entities.EMPTY)
                    {
                        validGridTile = true;   // Bottom boundary
                    }
                }
                else
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] != (int)Entities.EMPTY)
                    {
                        validGridTile = true;   // Top boundary
                    }
                }
            }
        }
        else
        {
            // Against left or right
            if (spawnPos.x == xGridMin)
            {
                if (spawnPos.y == yGridMin)
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y+1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] != (int)Entities.EMPTY)
                    {
                        
                        validGridTile = true;   // Bottom left corner
                    }
                }
                else if (spawnPos.y == yGridMax)
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y-1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] != (int)Entities.EMPTY)
                    {
                        
                        validGridTile = true;   // Top left corner
                    }
                }
                else
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] != (int)Entities.EMPTY)
                    {
                        validGridTile = true;   // Left boundary
                    }
                }
            }
            else
            {
                if (spawnPos.y == yGridMin)
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y+1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] != (int)Entities.EMPTY)
                    {
                        validGridTile = true;   // Bottom right corner
                    }
                }
                else if (spawnPos.y == yGridMax)
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y-1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] != (int)Entities.EMPTY)
                    {
                        validGridTile = true;   // Top right corner
                    }
                }
                else
                {
                    if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y-1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] != (int)Entities.EMPTY || GridTracker.tileLocation[(int)spawnPos.x-1, (int)spawnPos.y] != (int)Entities.EMPTY)
                    {
                        validGridTile = true;   // Right boundary
                    }
                }
            }
        }

        if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == (int)Entities.EMPTY && validGridTile == true)
        {
            if (StructureBehaviour.gameStatus == "Beginning")
            {
                // Place ground at mouse position
                Position pos = Utils.GetMousePosition();
                GameObject ScriptObject = GameObject.Find("ScriptObject");
                GroundClass groundScript = ScriptObject.GetComponent<GroundClass>();
                GridTracker.CreateEntityWithCost(pos, Entities.GRASS, "GroundTile", 1, 25);
            }
            else
            {
                // Place ground at template position
                Position pos = Utils.GetTemplatePosition();
                GameObject ScriptObject = GameObject.Find("ScriptObject");
                GroundClass groundScript = ScriptObject.GetComponent<GroundClass>();
                GridTracker.CreateEntityWithCost(pos, Entities.GRASS, "GroundTile", 1, 25);
            }
        }
        validGridTile = false;
    }

    void PlaceFarm()
    {
        if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == (int)Entities.GRASS)
        {
            Position spawnPosition = Utils.GetTemplatePosition();
            GridTracker.CreateEntityWithCost(spawnPosition, Entities.FARM, "FarmTile", 1, 100);
        }
    }

   void PlaceTownCenter()
    {
        Debug.Log("PlaceTownCeter was pressed");
        if (GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] == (int)Entities.GRASS && GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y+1] == (int)Entities.GRASS && GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == (int)Entities.GRASS && GridTracker.tileLocation[(int)spawnPos.x+1, (int)spawnPos.y] == (int)Entities.GRASS)
        {
            Debug.Log("Passed the PlaceTownCenter check");
            Position spawnPosition = Utils.GetTemplatePosition();
            Debug.Log("xSpawnPos: " + spawnPos.x + " ySpawnPos: " + spawnPos.y);
            GridTracker.CreateEntityWithCost(spawnPosition, Entities.TOWN_CENTER, "TownCenterTile", 4, 1000);
        }
    }
    
    public void DecisionMaker()
    {
        Debug.Log("DecisionMaker was called");
        Debug.Log(TemplateScript.currentlySelectedObject);
        Debug.Log(GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y + 1]);
        Debug.Log(GridTracker.GetEntityCount(Entities.TOWN_CENTER));
        Debug.Log(StructureBehaviour.currentTownCenterLimit);
        if (StructureBehaviour.gameStatus == "Beginning")
        {
            Position pos = Utils.GetMousePosition();
            spawnPos = new Vector2(pos.x, pos.y);
        }
        else
        {
            Position spawnPosition = Utils.GetTemplatePosition();
            spawnPos = new Vector2(spawnPosition.x, spawnPosition.y);
        }

        // Determine which structure to place
        if (TemplateScript.currentlySelectedObject == "GroundPlacer" && GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 0 && GridTracker.GetEntityCount(Entities.GRASS) < StructureBehaviour.currentGroundLimit)
        {
            PlaceGround();
            Destroy(GameObject.Find(TemplateScript.currentlySelectedObject + "(Clone)"));
            TemplateScript.isAnObjectSelected = false;
        }
        else if (TemplateScript.currentlySelectedObject == "FarmPlacer" && GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 1 && GridTracker.GetEntityCount(Entities.FARM) < StructureBehaviour.currentFarmLimit)
        {
            PlaceFarm();
            Destroy(GameObject.Find(TemplateScript.currentlySelectedObject + "(Clone)"));
            TemplateScript.isAnObjectSelected = false;
        }
        else if (TemplateScript.currentlySelectedObject == "TownCenterPlacer" && GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y+1] == 1 && GridTracker.GetEntityCount(Entities.TOWN_CENTER) < StructureBehaviour.currentTownCenterLimit)
        {
            Debug.Log("Passed the town center checks in decision maker");
            PlaceTownCenter();
            Destroy(GameObject.Find(TemplateScript.currentlySelectedObject + "(Clone)"));
            TemplateScript.isAnObjectSelected = false;
        }
        else
        {
            // Nothing
        }
    }

}
