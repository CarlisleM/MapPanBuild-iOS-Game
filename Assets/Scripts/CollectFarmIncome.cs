﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFarmIncome : MonoBehaviour {
    
    void Update () {
        if (PlacementScript.isAnObjectSelected == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (gridTracker.tileLocation[(int)Mathf.Round(worldPoint.x), (int)Mathf.Round(worldPoint.y)] == 3)
                {
                    Debug.Log("Clicked on a farm");
                }
            }
        }
	}

}
