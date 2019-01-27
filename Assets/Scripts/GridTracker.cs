using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;

public class GridTracker : MonoBehaviour {

    // What does this mean???
    public static List<GameObject> historicalGroundGameObjects;


    // This is the coords of the previous created grounds
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

    public static int GetEntityCount(Entities entity)
    {
        int count = 0;

        for (int i = 0; i < tileLocation.GetLength(0); i++)
        {
            for (int j = 0; j < tileLocation.GetLength(1); j++)
            {
                if (tileLocation[i, j] == (int) entity)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public static void AddTile(Position pos, Entities entity)
    {
        Ground groundTile = new Ground(pos.x, pos.y);
        GridTracker.tileLocation[pos.x, pos.y] = (int)entity;

        GameObject go = Instantiate(Resources.Load("GroundTile"), new Vector3(pos.x, pos.y), Quaternion.identity) as GameObject;

        historicalGroundGameObjects.Add(go);
        historicalPositions.Add(pos);
    }

    public static void Undo()
    {
        if (historicalGroundGameObjects.Count > 0) 
        {
            // update the farm grid
            Position lastPosition = historicalPositions[historicalPositions.Count - 1];
            tileLocation[lastPosition.x, lastPosition.y] = (int)Entities.EMPTY;
            historicalPositions.RemoveAt(historicalPositions.Count - 1);

            // remove the actual object from the scene
            GameObject lastObject = historicalGroundGameObjects[historicalGroundGameObjects.Count - 1];
            historicalGroundGameObjects.RemoveAt(historicalGroundGameObjects.Count - 1);
            Destroy(lastObject);
        }
    }
}
