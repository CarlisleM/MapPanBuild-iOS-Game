using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStructures : MonoBehaviour {

    public GameObject build_ui_panel;
    public GameObject ground;
    public GameObject farm;
    public GameObject town_center;

    // Display all UI structures avaialble for current skill level
    public void OpenPanel()
    {
        if (build_ui_panel != null)
        {
            bool isActive = build_ui_panel.activeSelf;
            build_ui_panel.SetActive(!isActive);
        }

        // Change UI based on the players level
        if (StructureBehaviour.currentLevel == 1)
        {
            ground.SetActive(true);
            farm.SetActive(true);
        }
        else if (StructureBehaviour.currentLevel == 2)
        {
            ground.SetActive(true);
            farm.SetActive(true);
            town_center.SetActive(true);
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
