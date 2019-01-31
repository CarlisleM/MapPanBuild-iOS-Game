using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;

public class GridTracker : MonoBehaviour {

    [SerializeField]
    public GameObject Button;

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
    public static int GetEntityCount(Entities entity, int structureSize)
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

        return count/structureSize;
    }

    // Instantiate a tile and subtract from the players money
    public static void CreateEntityWithCost(Position pos, Entities entity, string tileType, int structureSize, int cost)
    {
        AddTile(pos, entity, tileType, structureSize);
        StructureBehaviour.currentMoney = StructureBehaviour.currentMoney - cost;
    }

    // pos = position of tile               
    // entity = type of tile represented as an int    
    // tileType = type of tile as a string  
    // structureSize = number of grid squares it occupies
    public static void AddTile(Position pos, Entities entity, string tileType, int structureSize)
    {
        if (structureSize == 1)
        {
            tileLocation[pos.x, pos.y] = (int)entity;
        }
        else if (structureSize == 2)
        {
            tileLocation[pos.x, pos.y] = (int)entity;
            tileLocation[pos.x+1, pos.y] = (int)entity;
        }
        else
        {
            tileLocation[pos.x, pos.y] = (int)entity;
            tileLocation[pos.x+1, pos.y] = (int)entity;
            tileLocation[pos.x, pos.y+1] = (int)entity;
            tileLocation[pos.x+1, pos.y+1] = (int)entity;
        }

        if (structureSize == 4) // If placing the town center, place it off center to align with the grid
        {
            GameObject go = Instantiate(Resources.Load(tileType), new Vector3(pos.x, pos.y), Quaternion.identity) as GameObject;
            Vector3 temp = new Vector3(0.5f, 0.5f, 0);
            go.transform.position += temp;
            historicalGroundGameObjects.Add(go);
        }
        else
        {
            GameObject go = Instantiate(Resources.Load(tileType), new Vector3(pos.x, pos.y), Quaternion.identity) as GameObject;
            historicalGroundGameObjects.Add(go);
        }

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
