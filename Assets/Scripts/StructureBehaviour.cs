using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureBehaviour : MonoBehaviour {


    // Able to buy more land
    // Costs more as you get more land ie after 10 new blocks of land costs 100 per block instead of 50 (this is done to slow down your expansion rate)

    public static string gameStatus = "Beginning";
    
    public GameObject UICanvas;
    public GameObject BeginnerCanvas;
    public GameObject Blocker1;
    public GameObject Blocker2;

    public static int currentLevel = 1;
	public static int currentMoney = 100;

    int groundLimit = 1;
    int townCenterLimit = 1;
	int farmLimit = 1;
    
	public static int thingyCount;

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
    public static StructureLimits level1 = new StructureLimits(25, 1, 2);
	public static StructureLimits level2 = new StructureLimits(35, 1, 5);
	public static StructureLimits level3 = new StructureLimits(50, 2, 10);
	public static StructureLimits level4 = new StructureLimits(75, 2, 15);
	public static StructureLimits level5 = new StructureLimits(100, 3, 20);
    
    void Update()
    {

        //for (int i = 0; i < PlaceStructures.farmInstances.Count; i++)
        //{ 
        //    FarmIncome farmIncomeScript = PlaceStructures.farmInstances[i].GetComponent<FarmIncome>();
        //}
        
        if (PlacementScript.counter == 20)
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
            UICanvas.SetActive(true);
            BeginnerCanvas.SetActive(false);
            Blocker1.SetActive(false);
            Blocker2.SetActive(false);
            //   UICanvas.SetActive(true);
        }
        
        // Farm Structure Stuff
        if (GameObject.Find("GroundTile(Clone)") != null)
        {   // If a farm exists
            // Count the number of farms
            GameObject[] thingyToFind = GameObject.FindGameObjectsWithTag("GroundTile");
            thingyCount = thingyToFind.Length - 24; // Number of tiles minus the starting titles that already exist

        }

        // Requirements to upgrade to the next level
        // Already level 1
        if ((GameObject.Find("TownCenter(Clone)") != null) && (GameObject.Find("Farm(Clone)") != null) && currentMoney >= 1000 && currentLevel == 1) // Level 2 = $1000 + at least one farm + at least one town center
        {
            Debug.Log("You are able to upgrade to the next level.");
        }
        else if (currentLevel == 2)
        {
            // Current level is 2
        }
        else if (currentLevel == 3)
        {
            // Current level is 3
        }
        else if (currentLevel == 4)
        {
            // Current level is 4
        }
        else
        {
            // Current level is 5
        }

	}

}
