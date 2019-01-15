using UnityEngine;
using System.Collections;

public class TemplateScript : MonoBehaviour {

    [SerializeField]
    private GameObject finalObject;
    [SerializeField]
    private GameObject finalObject2;

    private Vector2 pos;
    private Vector2 spawnPos;

    [SerializeField]
    private LayerMask allTilesLayer;

    // If position of template rather than position of mouse

    private void Update()
    {

    }

    public void cancel()
    {

    }

    public void placeGrass()
    {
        if (GameObject.Find("GrassTemplate(Clone)") != null)
        {
            pos = GameObject.Find("GrassTemplate(Clone)").transform.position;
        }
        else if (GameObject.Find("HouseTemplate(Clone)"))
        {
            pos = GameObject.Find("HouseTemplate(Clone)").transform.position;
        }
        
        RaycastHit2D rayHit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity, allTilesLayer);

        if (rayHit.collider != null)
        { // If we dont hit anything
            if (rayHit.collider.gameObject.tag == "GrassTile" && GameObject.Find("HouseTemplate(Clone)") != null)
            {
                spawnPos = new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
                Debug.Log("Called 3");
                Instantiate(finalObject2, spawnPos, Quaternion.identity);
                StructureBehaviour.currentMoney = StructureBehaviour.currentMoney - 100;
                Debug.Log (StructureBehaviour.currentMoney);
            }
        }
        else if (rayHit.collider == null && GameObject.Find("GrassTemplate(Clone)") != null)
        {
            spawnPos = new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));

            Debug.Log("Generated tile");
            Instantiate(finalObject, spawnPos, Quaternion.identity);
        }
        else
        {
            Debug.Log(this.gameObject.name);    // Place
            Debug.Log(this.gameObject.tag); // Untagged
            Debug.Log(rayHit.collider); // Null
            Debug.Log("test");
        }

    }

}
