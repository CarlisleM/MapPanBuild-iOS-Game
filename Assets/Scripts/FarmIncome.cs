using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;

public class FarmIncome : MonoBehaviour {

    [SerializeField]
    public int currentIncome = 0;

    float elapsed = 0f;

    public void collectFarmIncome()
    {
        StructureBehaviour.currentMoney = StructureBehaviour.currentMoney + currentIncome;
        currentIncome = 0;
    }

    void Update()
    {
            if (TemplateScript.isAnObjectSelected == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Position pos = Utils.GetMousePosition();
                    if (GridTracker.tileLocation[pos.x, pos.y] == 3)
                    {
                        Debug.Log("Clicked on a farm");
                        Debug.Log(currentIncome);
                    }
                }
            }
     
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
