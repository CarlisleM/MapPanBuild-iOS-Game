using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundClass : MonoBehaviour {

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

    public static void createGround(Vector2 spawnPos)
    {
        Ground groundTile = new Ground((int)spawnPos.x, (int)spawnPos.y);
        gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] = 1; 
        Instantiate(Resources.Load("GroundTile"), spawnPos, Quaternion.identity);
    }

}
