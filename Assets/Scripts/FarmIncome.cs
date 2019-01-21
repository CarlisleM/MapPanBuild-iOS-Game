using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmIncome : MonoBehaviour {

    [SerializeField]
    public int thirst = 0;

    float elapsed = 0f;

    private Vector2 pos;
    private Vector2 spawnPos;

    [SerializeField]
    private LayerMask allTilesLayer;

    public void collectFarmIncome()
    {
        StructureBehaviour.currentMoney = StructureBehaviour.currentMoney + thirst;
        Debug.Log(StructureBehaviour.currentMoney);
        thirst = 0;
    }

    void Update()
    {


        // If clicked, select object, display collect button
        if (Input.GetMouseButtonDown(0))
        {
            // Get position of mouse click
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos = new Vector2(Mathf.Round(worldPoint.x), Mathf.Round(worldPoint.y));
            
            // Check what we hit
            RaycastHit2D rayHit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity, allTilesLayer);
            
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
        if (thirst < 100)
        {
            thirst++;
        }
    }
    
}

    /*
    if (rayHit.collider != null) // If we dont hit anything
    {

    if (rayHit.collider.gameObject.tag == "GrassTile" && GameObject.Find("HouseTemplate(Clone)") != null)

     
    else if (rayHit.collider == null && GameObject.Find("GroundPlacer(Clone)") != null) // If we hit something and grass template exists
    */