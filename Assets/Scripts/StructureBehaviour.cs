using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureBehaviour : MonoBehaviour {
	
	int currentLevel = 1;
	public static int currentMoney = 100;

	int townCenterLimit = 1;
	int farmLimit = 1;

	struct StructureLimits {
		//Variable declaration
		//Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
		public int Town_center_limit;
		public int Farm_limit;

		//Constructor (not necessary, but helpful)
		public StructureLimits(int town_center_limit, int farm_limit) {
			this.Town_center_limit = town_center_limit;
			this.Farm_limit = farm_limit;
		}
	}

	StructureLimits level1 = new StructureLimits(1, 2);
	StructureLimits level2 = new StructureLimits(1, 5);
	StructureLimits level3 = new StructureLimits(2, 10);
	StructureLimits level4 = new StructureLimits(2, 15);
	StructureLimits level5 = new StructureLimits(3, 20);

	// Use this for initialization
	void Start () {
		Debug.Log(level1.Farm_limit);	
		Debug.Log(level2.Farm_limit);
	}
	
	// Update is called once per frame
	void Update () {


		if (currentLevel == 1) {

		}

		//

		// Farm Structure Stuff
		if (GameObject.Find ("HouseTile(Clone)") != null) {	// If a farm exists
			// Count the number of farms
			GameObject[] thingyToFind = GameObject.FindGameObjectsWithTag ("HouseTile");
			int thingyCount = thingyToFind.Length;
	//		Debug.Log (thingyCount);

		}



		// Requirements to upgrade to the next level
		// Already level 1
		if ((GameObject.Find ("TownCenter(Clone)") != null) && (GameObject.Find ("Farm(Clone)") != null) && currentMoney >= 1000 && currentLevel == 1) { // Level 2 = $1000 + at least one farm + at least one town center
			// Now able to upgrade
			/*
			if (clicked) {
				currentMoney = currentMoney - 1000;
				currentLevel = 2;
			}
			*/
		} else if (currentLevel == 2) {
			// Current level is 2
		} else if (currentLevel == 3) {
			// Current level is 3
		} else if (currentLevel == 4) {
			// Current level is 4
		} else {
			// Current level is 5
		}


	}
}
