using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmIncome : MonoBehaviour {

    [SerializeField]
    public static int currentIncome = 0;

    float elapsed = 0f;

    public void collectFarmIncome()
    {
        StructureBehaviour.currentMoney = StructureBehaviour.currentMoney + currentIncome;
        Debug.Log(StructureBehaviour.currentMoney);
        currentIncome = 0;
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
        if (currentIncome < 100)
        {
            currentIncome++;
        }
    }
    
}
