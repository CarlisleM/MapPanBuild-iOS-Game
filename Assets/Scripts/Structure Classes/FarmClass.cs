using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmClass : MonoBehaviour {

    public static int farmCount;
    
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
        Farm farmTile = new Farm(0, (int)spawnPos.x, (int)spawnPos.y);
        GridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] = 3;
        Instantiate(Resources.Load("FarmTile"), spawnPos, Quaternion.identity);
        StructureBehaviour.currentMoney = StructureBehaviour.currentMoney - 100;
        farmCount++;
    }

}
