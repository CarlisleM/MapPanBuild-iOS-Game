using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmIncome : MonoBehaviour {

    [SerializeField]
    public int thirst = 0;

    float elapsed = 0f;
    
    public void collectFarmIncome()
    {
        StructureBehaviour.currentMoney = StructureBehaviour.currentMoney + thirst;
        Debug.Log(StructureBehaviour.currentMoney);
        thirst = 0;
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
        if (thirst < 100)
        {
            thirst++;
        }
    }
    /*

    IEnumerator Example()
    {
     //   print(Time.time);
        yield return new WaitForSeconds(1);
        
     //   print(Time.time);
    }

    // Update is called once per frame
    void Update () {

        if (thirst < 150)
        {
            StartCoroutine(Example());
            //
        //    print(thirst);
        }

    }

    */

}
