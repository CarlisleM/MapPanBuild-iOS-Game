using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;

public class GridTracker : MonoBehaviour {

    // List containing GameObject's in the order they were created
    public static List<GameObject> historicalGroundGameObjects;
    
    // This is the coords of the previously created grounds
    public static List<Position> historicalPositions;

    public static int[,] tileLocation = new int[10, 10] {    // 10 Rows by 10 Columns
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 2, 2, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 2, 2, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    };

    public void Start()
    {
        historicalGroundGameObjects = new List<GameObject>();
        historicalPositions = new List<Position>();
    }

    // Count the number of a specific tile type
    public static int GetEntityCount(Entities entity)
    {
        int count = 0;

        for (int i = 0; i < tileLocation.GetLength(0); i++)
        {
            for (int j = 0; j < tileLocation.GetLength(1); j++)
            {
                if (tileLocation[i, j] == (int)entity)
                {
                    count++;
                }
            }
        }

        if ((int)entity == 2)
        {
            count = count / 4;
        }

        return count;
    }

    // Instantiate a tile and subtract from the players money
    public static void CreateEntityWithCost(Position pos, Entities entity, string tileType, int tileSize, int cost)
    {
        Debug.Log("Called CreateEntityWithCosT");
        AddTile(pos, entity, tileType, tileSize);
        StructureBehaviour.currentMoney = StructureBehaviour.currentMoney - cost;
    }

    // pos = position of tile               
    // entity = type of tile represented as an int    
    // tileType = type of tile as a string  
    // tileSize = number of grid squares it occupies
    public static void AddTile(Position pos, Entities entity, string tileType, int tileSize)
    {
        Debug.Log("Called AddTile");
        if (tileSize == 1)
        {
            tileLocation[pos.x, pos.y] = (int)entity;
        }
        else if (tileSize == 2)
        {
            tileLocation[pos.x, pos.y] = (int)entity;
            tileLocation[pos.x+1, pos.y] = (int)entity;
        }
        else
        {
            Debug.Log("Entered the 4 tile segment");
            tileLocation[pos.x, pos.y] = (int)entity;
            tileLocation[pos.x+1, pos.y] = (int)entity;
            tileLocation[pos.x, pos.y+1] = (int)entity;
            tileLocation[pos.x+1, pos.y+1] = (int)entity;
        }

        GameObject go = Instantiate(Resources.Load(tileType), new Vector3(pos.x, pos.y), Quaternion.identity) as GameObject;

        historicalGroundGameObjects.Add(go);
        historicalPositions.Add(pos);
    }

    public static void Undo()
    {
        if (historicalGroundGameObjects.Count > 0) 
        {
            // Update the grid and remove from the list
            Position lastPosition = historicalPositions[historicalPositions.Count - 1];
            tileLocation[lastPosition.x, lastPosition.y] = (int)Entities.EMPTY;
            historicalPositions.RemoveAt(historicalPositions.Count - 1);

            // Remove the actual object from the scene
            GameObject lastObject = historicalGroundGameObjects[historicalGroundGameObjects.Count - 1];
            historicalGroundGameObjects.RemoveAt(historicalGroundGameObjects.Count - 1);
            Destroy(lastObject);
        }
    }
}
