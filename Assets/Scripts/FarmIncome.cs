using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmIncome : MonoBehaviour {

    [SerializeField]
    public int money = 0;

    private Vector2 currentPos;

    float elapsed = 0f;

    public void collectFarmIncome()
    {
        StructureBehaviour.currentMoney = StructureBehaviour.currentMoney + money;
        Debug.Log(StructureBehaviour.currentMoney);
        money = 0;
    }

    void Update()
    {


        //if (PlacementScript.isAnObjectSelected == true)
        //{
        //    Vector3 worldCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    currentPos = new Vector2(Mathf.Round(worldCurrentPos.x), Mathf.Round(worldCurrentPos.y));
        //    Debug.Log("here");
        //    Debug.Log(gridTracker.tileLocation[(int)currentPos.x, (int)currentPos.y]);
        //}

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
