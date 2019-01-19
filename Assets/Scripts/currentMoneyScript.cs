using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentMoneyScript : MonoBehaviour {

    Text currentMoneyText;

    // Use this for initialization
    void Start () {
        currentMoneyText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (StructureBehaviour.gameStatus != "Beginning")
        {
            currentMoneyText.text = "Current money: " + StructureBehaviour.currentMoney;
        }
    }
}
