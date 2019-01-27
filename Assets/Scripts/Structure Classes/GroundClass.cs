using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;

public class GroundClass : MonoBehaviour {
    
    public static int groundCount = 0;
    public static List<GameObject> groundTileList;
    
    public class Ground
    {
        public int xPosition;
        public int yPosition;
        private Vector2 spawnPos;

        public Ground(int xPos, int yPos)
        {
            xPosition = xPos;
            yPosition = yPos;
        }
    }

    void Start()
    {
        groundTileList = new List<GameObject>();
    }

    public void CreateGround(Position spawnPos)
    {
        if (GridTracker.tileLocation[spawnPos.x, spawnPos.y] == (int)Entities.EMPTY)
        {
            GridTracker.AddTile(spawnPos, Entities.GRASS);
        }
    }

}
