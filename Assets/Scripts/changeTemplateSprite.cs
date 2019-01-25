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
                spriteRenderer.sprite = StructureCantExist;

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
                    // Nothing
                }
            }
            else if (PlacementScript.currentlySelectedObject == "TownCenterPlacer")
            {
                currentPos = GameObject.Find(PlacementScript.currentlySelectedObject + "(Clone)").transform.position;
                if (gridTracker.tileLocation[(int)currentPos.x, (int)currentPos.y+1] == 1 && gridTracker.tileLocation[(int)currentPos.x + 1, (int)currentPos.y+1] == 1 && gridTracker.tileLocation[(int)currentPos.x, (int)currentPos.y] == 1 && gridTracker.tileLocation[(int)currentPos.x + 1, (int)currentPos.y] == 1)    // If vacant tile
                {
                spriteRenderer.sprite = StructureValid;
                }
                else if (gridTracker.tileLocation[(int)currentPos.x, (int)currentPos.y+1] == 0 || gridTracker.tileLocation[(int)currentPos.x + 1, (int)currentPos.y+1] == 0 || gridTracker.tileLocation[(int)currentPos.x, (int)currentPos.y] == 0 || gridTracker.tileLocation[(int)currentPos.x + 1, (int)currentPos.y] == 0)  // If not a vacant tile
                {
                    spriteRenderer.sprite = StructureNotValid;
                }
                else
                {
                    // Nothing
                }
            }
            else// If placing anything other than ground
            {
                spriteRenderer.sprite = StructureCantExist;

                if (gridTracker.tileLocation[(int)currentPos.x, (int)currentPos.y] == 1)    // If vacant tile
                {
                    spriteRenderer.sprite = StructureValid;
                }
                else if (gridTracker.tileLocation[(int)currentPos.x, (int)currentPos.y] != 1)  // If not a vacant tile
                {
                    spriteRenderer.sprite = StructureNotValid;
                }
                else
                {
                    // Nothing
                }
            }
        }
    }

}
