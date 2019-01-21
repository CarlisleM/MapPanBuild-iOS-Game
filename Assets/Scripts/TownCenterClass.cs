using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCenterClass : MonoBehaviour {

    public class TownCenter
    {
        public int xPosition;
        public int yPosition;
        private Vector2 spawnPos;

        public TownCenter(int xPos, int yPos)
        {
            xPosition = xPos;
            yPosition = yPos;
        }
    }

    public static void createTownCenter(Vector2 spawnPos)
    {
        Debug.Log("Called TownCenter Class");
        TownCenter groundTile = new TownCenter((int)spawnPos.x, (int)spawnPos.y);
        gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] = 2;
        Instantiate(Resources.Load("TownCenterTile"), spawnPos, Quaternion.identity);
    }

}

