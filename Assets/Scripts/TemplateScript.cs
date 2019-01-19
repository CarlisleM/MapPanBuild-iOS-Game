using UnityEngine;
using System.Collections.Generic;
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

    public GameObject Panel;
    public GameObject Cancel_Place_Panel;
    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Place;
    public GameObject Cancel;
    
    public static List<GameObject> groundInstances = new List<GameObject>();
    public static List<GameObject> farmInstances = new List<GameObject>();
    
    private void Update()
    {
       
    }

    public void cancel()
    {

    }

    public void placeGrass()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (GameObject.Find("GrassTemplate(Clone)") != null)
        {
            if (StructureBehaviour.gameStatus == "Beginning")
            {
                pos = new Vector2(Mathf.Round(worldPoint.x), Mathf.Round(worldPoint.y));
            }
            else
            {
                pos = GameObject.Find("GrassTemplate(Clone)").transform.position;
            }   
        }
        else if (GameObject.Find("HouseTemplate(Clone)"))
        {
            pos = GameObject.Find("HouseTemplate(Clone)").transform.position;
        }
        
        RaycastHit2D rayHit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity, allTilesLayer);

        if (rayHit.collider != null) // If we dont hit anything
        { 
            if (rayHit.collider.gameObject.tag == "GrassTile" && GameObject.Find("HouseTemplate(Clone)") != null)
            {
                Debug.Log("Instantiate 1");
                spawnPos = new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));

                // Instantiate farms into a list
                GameObject farmTileList = (GameObject)Instantiate(finalObject2, spawnPos, Quaternion.identity);
                farmInstances.Add(farmTileList);
                
                GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = true;

                // Destroy Template and return to structure UI
                GameObject go = GameObject.Find(PlacementScript.currentlySelectedObject); // Find currently selected object
                if (go)
                {
                    Destroy(go.gameObject); // Destroy currently selected object

                    Button.SetActive(true);
                    Button1.SetActive(true);
                    Button2.SetActive(true);
                    Cancel_Place_Panel.SetActive(false);

                }

                StructureBehaviour.currentMoney = StructureBehaviour.currentMoney - 100;
                Debug.Log(StructureBehaviour.currentMoney);
            }
        }
        else if (rayHit.collider == null && GameObject.Find("GrassTemplate(Clone)") != null) // If we hit something and grass template exists
        {
            if (StructureBehaviour.gameStatus == "Beginning")
            {
                spawnPos = new Vector2(Mathf.Round(worldPoint.x), Mathf.Round(worldPoint.y));
            }
            else
            {
                spawnPos = new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
            }
            
            PlacementScript.counter++;
            
            // Instantiate ground into a list
            GameObject groundTileList = (GameObject)Instantiate(finalObject, spawnPos, Quaternion.identity);
            groundInstances.Add(groundTileList); 

            GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = true;
            
            // Destroy Template and return to structure UI
            GameObject go = GameObject.Find(PlacementScript.currentlySelectedObject); // Find currently selected object
            if (go)
            {
                Destroy(go.gameObject); // Destroy currently selected object

                Button.SetActive(true);
                Button1.SetActive(true);
                Button2.SetActive(true);
                Cancel_Place_Panel.SetActive(false);
            }
        }
        else
        {

        }



    }

}
