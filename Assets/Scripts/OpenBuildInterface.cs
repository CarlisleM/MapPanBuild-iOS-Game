using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBuildInterface : MonoBehaviour {

	public GameObject Panel;
	public GameObject Cancel_Place_Panel;
	public GameObject Button;
	public GameObject Button1;
	public GameObject Button2;
	public GameObject Button3;
	public GameObject Place;
	public GameObject Cancel;

	public void farmSelected() {
		Button.SetActive (false);
		Button1.SetActive (false);
		Button2.SetActive (false);
	}

	public void cancel() {

        // Destroy whatever object is currenlty selected 
        GameObject go = GameObject.Find(PlacementScript.currentlySelectedObject);
        if (go)
        {
            Destroy(go.gameObject);
        }

        Button.SetActive (true);
		Button1.SetActive (true);
		Button2.SetActive (true);
	}

	public void place() {

	}

	public void OpenPanel() {
		if (Panel != null) {
			bool isActive = Panel.activeSelf;
			Panel.SetActive (!isActive);
		}

		// Change UI based on the players level
		if (StructureBehaviour.currentLevel == 1 && StructureBehaviour.thingyCount < StructureBehaviour.level1.Farm_limit) {
			Button1.SetActive(true);
			Button2.SetActive(true);
		} else if (StructureBehaviour.currentLevel == 2) {
            Button1.SetActive(true);
            Button2.SetActive(true);
            Button3.SetActive(true);
        } else if (StructureBehaviour.currentLevel == 3) {

		} else if (StructureBehaviour.currentLevel == 4) {

		} else {

		}
	}

}
