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
        currentIncomeText = GetComponent<Text>();
    }


}
