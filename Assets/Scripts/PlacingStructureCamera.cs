using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingStructureCamera : MonoBehaviour {

    public int distance = -10;

    void Update()
    {

        GameObject go = GameObject.Find(TemplateScript.currentlySelectedObject); // Find currently selected object
        
        if (go)
        {
            this.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, distance);
        }

    }

}
