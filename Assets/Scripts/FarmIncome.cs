using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmIncome : MonoBehaviour {

    [SerializeField]
    public int money = 0;

    float elapsed = 0f;

    public void collectFarmIncome()
    {
        StructureBehaviour.currentMoney = StructureBehaviour.currentMoney + money;
        Debug.Log(StructureBehaviour.currentMoney);
        money = 0;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            OutputTime();
        }
    }

    void OutputTime()
    {
        if (money < 100)
        {
            money++;
        }
    }
    
}
