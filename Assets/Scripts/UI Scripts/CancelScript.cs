using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelScript : MonoBehaviour {

    public GameObject build_ui_panel;
    public GameObject place_cancel_panel;
    public GameObject ground;
    public GameObject farm;
    public GameObject town_center;

    public void Cancel()
    {
        TemplateScript.isAnObjectSelected = false;
        GameObject.Find("Main Camera").GetComponent<CameraHandler>().enabled = true;

        // Destroy whatever object is currenlty selected 
        GameObject go = GameObject.Find(TemplateScript.currentlySelectedObject + "(Clone)");
        if (go)
        {
            Destroy(go.gameObject);
        }

        build_ui_panel.SetActive(true);
        ground.SetActive(true);
        farm.SetActive(true);
        town_center.SetActive(true);
        place_cancel_panel.SetActive(false);
    }

}
