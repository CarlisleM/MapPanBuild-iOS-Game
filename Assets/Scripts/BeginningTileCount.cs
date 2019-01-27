using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GrassGame;

public class BeginningTileCount : MonoBehaviour {

    Text currentTileCount;
    
    void Start () {
        currentTileCount = GetComponent<Text>();
    }
	
	void Update () {
        if (StructureBehaviour.gameStatus == "Beginning")
        {
            currentTileCount.text = "Ground tiles remaining: " + (20-GridTracker.GetEntityCount(Entities.GRASS));
        }
    }
    
}
