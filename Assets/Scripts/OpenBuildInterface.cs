using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBuildInterface : MonoBehaviour {

	public GameObject BuildUIPanel;
	public GameObject PlaceCancelPanel;
	public GameObject BuildUI;
	public GameObject Ground;
	public GameObject Farm;
	public GameObject TownCenter;
	public GameObject Place;
	public GameObject Cancel;

	public void buidlingSelected()
    {
        // Disable all other UI buttons except cancel/place
        BuildUI.SetActive(false);
		Ground.SetActive(false);
		Farm.SetActive(false);
        PlaceCancelPanel.SetActive(true);
	}

	public void cancel()
    {

        GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = true;

        // Destroy whatever object is currenlty selected 
        GameObject go = GameObject.Find(PlacementScript.currentlySelectedObject);
        if (go)
        {
            Destroy(go.gameObject);
        }

        BuildUI.SetActive (true);
		Ground.SetActive (true);
		Farm.SetActive (true);
        PlaceCancelPanel.SetActive(false);
    }

	public void place()
    {

	}

    private void Update()
    {
      //  Debug.Log(StructureBehaviour.thingyCount);
        // If farm capacity for the players current level is not yet reached
        if (StructureBehaviour.thingyCount >= StructureBehaviour.level1.Farm_limit)
        {
            //                Debug.Log(StructureBehaviour.thingyCount);
            Ground.GetComponent<Button>().interactable = false;
        } else
        {
            Ground.GetComponent<Button>().interactable = true;
        }
    }

    // Display all UI structures avaialble for current skill level
    public void OpenPanel() 
    {
		if (BuildUIPanel != null)
        {
			bool isActive = BuildUIPanel.activeSelf;
            BuildUIPanel.SetActive (!isActive);
		}

		// Change UI based on the players level
		if (StructureBehaviour.currentLevel == 1)
        {
            Ground.SetActive(true);
            Farm.SetActive(true);
            
		}
        else if (StructureBehaviour.currentLevel == 2)
        {
            Ground.SetActive(true);
            Farm.SetActive(true);
            TownCenter.SetActive(true);
        }
        else if (StructureBehaviour.currentLevel == 3)
        {

		}
        else if (StructureBehaviour.currentLevel == 4)
        {

		}
        else
        {

		}
	}

}
