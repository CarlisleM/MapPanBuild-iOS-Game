using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void createGround(Vector2 spawnPos)
    {
        if (gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] == 0)
        {
            Ground groundTile = new Ground((int)spawnPos.x, (int)spawnPos.y);
            gridTracker.tileLocation[(int)spawnPos.x, (int)spawnPos.y] = 1;
            groundTileList.Add((GameObject)Instantiate(Resources.Load("GroundTile"), spawnPos, Quaternion.identity));
            StructureBehaviour.currentMoney = StructureBehaviour.currentMoney - 25;
            groundCount++;
        }
    }

}
