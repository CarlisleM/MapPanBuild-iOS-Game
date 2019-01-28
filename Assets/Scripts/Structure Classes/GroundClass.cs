using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;

public class GroundClass : MonoBehaviour {

    public static List<GameObject> groundTileList;

    void Start()
    {
        groundTileList = new List<GameObject>();
    }

    public void CreateGround(Position spawnPos)
    {
        if (GridTracker.tileLocation[spawnPos.x, spawnPos.y] == (int)Entities.EMPTY)
        {
            GridTracker.AddTile(spawnPos, Entities.GRASS, "GroundTile", 1);
        }
    }

}
