using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmClass : MonoBehaviour {

    public class Farm
    {
        public int moneyTimer;
        public int xPosition;
        public int yPosition;
        private Vector2 spawnPos;

        public Farm(int moneyTimer, int xPos, int yPos)
        {
            xPosition = xPos;
            yPosition = yPos;
        }
    }

    public static void createFarm(Vector2 spawnPos)
    {
        Debug.Log("Called Farm Class");
        Farm farmTile = new Farm(0, (int)spawnPos.x, (int)spawnPos.y);
        gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] = 3;
        Instantiate(Resources.Load("FarmTile"), spawnPos, Quaternion.identity);
    }

}
