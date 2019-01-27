using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GrassGame;

public class CollectFarmIncome : MonoBehaviour {

    public GameObject CollectFarmIncomeButton;
    Text currentIncomeText;

    void Start()
    {
     //   currentIncomeText = GetComponent<Text>();
    }

    void Update () {
        if (PlacementScript.isAnObjectSelected == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Position pos = Utils.GetPosition();
                if (gridTracker.tileLocation[pos.x, pos.y] == 3)
                {
                    Debug.Log("Clicked on a farm");
                    CollectFarmIncomeButton.SetActive(true);
                    currentIncomeText.text = "" + FarmIncome.currentIncome;

                }
            }
        }
	}

}
