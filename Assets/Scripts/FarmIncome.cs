using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;
using UnityEngine.UI;

public class FarmIncome : MonoBehaviour
{
    [SerializeField]
    public int currentIncome = 0;

    int i = 1;
    float elapsed = 0f;

    public GameObject CollectFarmIncomeButton;
    public Text currentIncomeText;

    int currentFarm;

    private void Start()
    {
        currentIncomeText = GetComponent<Text>();
    }

    //public void collectFarmIncome(currentFarm)
    //{
    //    Debug.Log("i was: " + i);
    //    StructureBehaviour.currentMoney = StructureBehaviour.currentMoney + PlaceStructures.farmList[i].farmIncome;
    //    PlaceStructures.farmList[i].farmIncome = 0;
    //}

    int CheckFarm()
    {
        if (TemplateScript.isAnObjectSelected == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Position pos = Utils.GetMousePosition();
                if (GridTracker.tileLocation[pos.x, pos.y] == 3)
                {
                    Debug.Log("Clicked on a farm");
                    for (i = 0; i < PlaceStructures.farmList.Count; i++)
                    {
                        if (PlaceStructures.farmList[i].xPosition == pos.x && PlaceStructures.farmList[i].yPosition == pos.y)
                        {
                            CollectFarmIncomeButton.SetActive(true);
                            currentFarm = i;
                            //               currentIncomeText.text = "" + PlaceStructures.farmList[i].farmIncome;
                            Debug.Log("We matched a farm at xPos: " + pos.x + " yPos: " + pos.y + " farm number: " + currentFarm + " with a current income of: " + PlaceStructures.farmList[i].farmIncome);
                            StructureBehaviour.currentMoney = StructureBehaviour.currentMoney + PlaceStructures.farmList[i].farmIncome;
                            PlaceStructures.farmList[i].farmIncome = 0;
                        }
                    }

                }
                else
                {
                    CollectFarmIncomeButton.SetActive(false);
                }
            }
        }
        return currentFarm;
    }

    void IncreaseFarmIncome()
    {
        elapsed += Time.deltaTime;

        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            for (i = 0; i < PlaceStructures.farmList.Count; i++)
            {
                if (PlaceStructures.farmList[i].farmIncome < 100)
                {
                    PlaceStructures.farmList[i].farmIncome = PlaceStructures.farmList[i].farmIncome + 1;
                }
            }
        }        

        i = 0;
    }
    
    private void Update()
    {
        CheckFarm();
        IncreaseFarmIncome();
    }

}
