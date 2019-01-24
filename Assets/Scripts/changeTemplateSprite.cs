using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTemplateSprite : MonoBehaviour {


    public Sprite StructureValid; // Drag your first sprite here
    public Sprite StructureNotValid; // Drag your second sprite here
    public Sprite StructureCantExist;

    private Vector2 currentPos;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
    }

    void Update()
    {
        if (PlacementScript.isAnObjectSelected == true)
        {
            currentPos = GameObject.Find(PlacementScript.currentlySelectedObject + "(Clone)").transform.position;

            if (PlacementScript.currentlySelectedObject == "GroundPlacer")  // If placing ground
            {
           //     if (currentPos.x < 0 || currentPos.x > gridTracker.tileLocation.GetLength(0) || currentPos.y < 0 || currentPos.y > gridTracker.tileLocation.GetLength(1))   // If out of bounds
           //     {
                    spriteRenderer.sprite = StructureCantExist;
    //            }
    //            else    // If not out of bounds
    //            {
                    if (gridTracker.tileLocation[(int)currentPos.x, (int)currentPos.y] == 0)    // If vacant tile
                    {
                        spriteRenderer.sprite = StructureValid;
                    }
                    else if (gridTracker.tileLocation[(int)currentPos.x, (int)currentPos.y] != 0)  // If not a vacant tile
                    {
                        spriteRenderer.sprite = StructureNotValid;
                    }
                    else
                    {
                        spriteRenderer.sprite = StructureCantExist;
                    }
              //  }
            }
            else    // If placing anything other than ground
            {
                if (gridTracker.tileLocation[(int)currentPos.x, (int)currentPos.y] == 1)    // If it is a grass tile
                {
                    spriteRenderer.sprite = StructureValid;
                }
                else
                {
                    spriteRenderer.sprite = StructureNotValid;
                }
            }
        }
    }

}



