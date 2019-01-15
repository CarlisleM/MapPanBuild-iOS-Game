using UnityEngine;
using System.Collections;

public class TemplateScript : MonoBehaviour {

    [SerializeField]
    private GameObject finalObject;

    private Vector2 pos;

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

     //   Debug.Log(GameObject.Find("GrassTemplate(Clone)").transform.position); // This gives us the location of the template
        Debug.Log("Called 1");
        if (GameObject.Find("GrassTemplate(Clone)") != null)
        {
            pos = GameObject.Find("GrassTemplate(Clone)").transform.position;
        }
        else if (GameObject.Find("HouseTemplate(Clone)"))
        {
            pos = GameObject.Find("HouseTemplate(Clone)").transform.position;
        }

        
        //        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, allTilesLayer);
        RaycastHit2D rayHit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity, allTilesLayer);
        Debug.Log(transform.position);
        Debug.Log(rayHit.collider);

        if (rayHit.collider != null)
        { // If we dont hit anything
            Debug.Log("Called 2");
            Debug.Log(rayHit.collider.gameObject.tag);
            if (rayHit.collider.gameObject.tag == "GrassTile" && this.gameObject.tag == "HouseTemplate")
            {
                Debug.Log("Called 3");
                Instantiate(finalObject, transform.position, Quaternion.identity);
                //				Debug.Log ("called");
                StructureBehaviour.currentMoney = StructureBehaviour.currentMoney - 100;
                //				Debug.Log (StructureBehaviour.currentMoney);
            }
        }
        else if (rayHit.collider == null && GameObject.Find("GrassTemplate(Clone)") != null)
        {
            Debug.Log("Called 4");

            Debug.Log(pos);
            transform.position = new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
            Debug.Log(transform.position);

            Debug.Log("Generated tile");
            Instantiate(finalObject, transform.position, Quaternion.identity);
            //            Instantiate(finalObject, GameObject.Find("GrassTemplate(Clone)").transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log(this.gameObject.name);    // Place
            Debug.Log(this.gameObject.tag); // Untagged
            Debug.Log(rayHit.collider); // Null
            Debug.Log("test");
        }

            Debug.Log("Called 5");
    }

}

