using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;

public class StructureBehaviour : MonoBehaviour {


    // Able to buy more land
    // Costs more as you get more land ie after 10 new blocks of land costs 100 per block instead of 50 (this is done to slow down your expansion rate)

    public static string gameStatus = "Beginning";
    
    public GameObject UICanvas;
    public GameObject BeginnerCanvas;

    public static int currentLevel = 1;
	public static int currentMoney = 900;   // 600

    public static int currentGroundLimit;
    public static int currentFarmLimit;
    public static int currentTownCenterLimit;

	// Structure containing all the level limitations
	public struct StructureLimits
    {
        public int Ground_limit;
        public int Town_center_limit;
		public int Farm_limit;
        
		public StructureLimits(int ground_limit, int town_center_limit, int farm_limit)
        {
            this.Ground_limit = ground_limit;
            this.Town_center_limit = town_center_limit;
			this.Farm_limit = farm_limit;
		}
	}

    // Level limitations - (Ground, Town Centers, Farms)
    public static StructureLimits level1 = new StructureLimits(25, 1, 4);
	public static StructureLimits level2 = new StructureLimits(35, 1, 5);
	public static StructureLimits level3 = new StructureLimits(50, 2, 10);
	public static StructureLimits level4 = new StructureLimits(75, 2, 17);
	public static StructureLimits level5 = new StructureLimits(100, 3, 26);
    
    void Update()
    {
        if (GridTracker.GetEntityCount(Entities.GRASS,1) == 20)
        {
            if (gameStatus == "Beginning")
            {
                GameObject go = GameObject.Find("GroundPlacer(Clone)"); // Find currently selected object
                if (go)
                {
                    Destroy(go.gameObject); // Destroy currently selected object
                }
            }
            gameStatus = "InProgress";
        }

        // Requirements to upgrade to the next level
        if (currentLevel == 1) // Level 2 = $1000 + at least one farm + at least one town center
        {
            currentGroundLimit = level1.Ground_limit;
            currentFarmLimit = level1.Farm_limit;
            currentTownCenterLimit = level1.Town_center_limit;
            if ((GameObject.Find("TownCenter(Clone)") != null) && (GameObject.Find("Farm(Clone)") != null) && currentMoney >= 1000)
            {
                Debug.Log("You are able to upgrade to level 2.");
            }
        }
        else if (currentLevel == 2 && currentGroundLimit == GridTracker.GetEntityCount(Entities.GRASS,1) && currentFarmLimit == GridTracker.GetEntityCount(Entities.FARM,1) && currentTownCenterLimit == GridTracker.GetEntityCount(Entities.TOWN_CENTER,4))
        {
            currentGroundLimit = level2.Ground_limit;
            currentFarmLimit = level2.Farm_limit;
            currentTownCenterLimit = level2.Town_center_limit;
            if (currentMoney >= 3000 && currentGroundLimit == GridTracker.GetEntityCount(Entities.GRASS,1) && currentFarmLimit == GridTracker.GetEntityCount(Entities.FARM,1) && currentTownCenterLimit == GridTracker.GetEntityCount(Entities.TOWN_CENTER,4))
            {
                Debug.Log("You are able to upgrade to level 3.");
            }
        }
        else if (currentLevel == 3)
        {
            currentGroundLimit = level3.Ground_limit;
            currentFarmLimit = level3.Farm_limit;
            currentTownCenterLimit = level3.Town_center_limit;
            if (currentMoney >= 5000 && currentGroundLimit == GridTracker.GetEntityCount(Entities.GRASS,1) && currentFarmLimit == GridTracker.GetEntityCount(Entities.FARM,1) && currentTownCenterLimit == GridTracker.GetEntityCount(Entities.TOWN_CENTER,4))
            {
                Debug.Log("You are able to upgrade to level 4");
            }
        }
        else if (currentLevel == 4)
        {
            currentGroundLimit = level4.Ground_limit;
            currentFarmLimit = level4.Farm_limit;
            currentTownCenterLimit = level4.Town_center_limit;
            if (currentMoney >= 7000 && currentGroundLimit == GridTracker.GetEntityCount(Entities.GRASS,1) && currentFarmLimit == GridTracker.GetEntityCount(Entities.FARM,1) && currentTownCenterLimit == GridTracker.GetEntityCount(Entities.TOWN_CENTER,4))
            {
                Debug.Log("You are able to upgrade to level 5.");
            }
        }
        else
        {
            currentGroundLimit = level5.Ground_limit;
            currentFarmLimit = level5.Farm_limit;
            currentTownCenterLimit = level5.Town_center_limit;
        }

    }

}
