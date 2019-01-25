using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginningTileCount : MonoBehaviour {

    Text currentTileCount;
    
    void Start () {
        currentTileCount = GetComponent<Text>();
    }
	
	void Update () {
        if (StructureBehaviour.gameStatus == "Beginning")
        {
            currentTileCount.text = "Ground tiles remaining: " + (20 -GroundClass.groundCount);
        }
    }

}
