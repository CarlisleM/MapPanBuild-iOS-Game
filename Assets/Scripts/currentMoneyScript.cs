using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentMoneyScript : MonoBehaviour {

    Text currentMoneyText;
    
    void Start()
    {
        currentMoneyText = GetComponent<Text>();
    }

    void Update()
    {
        if (StructureBehaviour.gameStatus != "Beginning")
        {
            currentMoneyText.text = "Current money: " + StructureBehaviour.currentMoney;
        }
    }

}
