using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject ui_canvas;
    public GameObject build_ui_panel;
    public GameObject place_cancel_Panel;
    public GameObject beginner_canvas;
    public GameObject build_ui_button;
    public GameObject ground_button;
    public GameObject farm_button;
    public GameObject town_center_button;

    private void Start()
    {
        ui_canvas.SetActive(false);
        build_ui_panel.SetActive(false);
        place_cancel_Panel.SetActive(false);
    }

    private void Update()
    {
        if (GridTracker.GetEntityCount(Entities.GRASS,1) == 20)
        {
            ui_canvas.SetActive(true);
            beginner_canvas.SetActive(false);
        }

        if (TemplateScript.isAnObjectSelected == true)
        {
            build_ui_button.SetActive(true);
            build_ui_panel.SetActive(false);
            place_cancel_Panel.SetActive(true);
        }
        else
        {
            build_ui_button.SetActive(true);
            place_cancel_Panel.SetActive(false);
        }

        if (StructureBehaviour.currentGroundLimit == GridTracker.GetEntityCount(Entities.GRASS, 1) || StructureBehaviour.currentMoney < 25)
        {
            ground_button.GetComponent<Button>().interactable = false;
            ground_button.GetComponent<Image>().color = new Color32(255, 255, 225, 153);
        }
        else
        {
            ground_button.GetComponent<Button>().interactable = true;
        }

        if (StructureBehaviour.currentFarmLimit == GridTracker.GetEntityCount(Entities.FARM, 1) || StructureBehaviour.currentMoney < 100)
        {
            farm_button.GetComponent<Button>().interactable = false;
            farm_button.GetComponent<Image>().color = new Color32(255, 255, 225, 153);
        }
        else
        {
            farm_button.GetComponent<Button>().interactable = true;
        }

        if (StructureBehaviour.currentTownCenterLimit == GridTracker.GetEntityCount(Entities.TOWN_CENTER, 4) || StructureBehaviour.currentMoney < 1000)
        {
            town_center_button.GetComponent<Button>().interactable = false;
            town_center_button.GetComponent<Image>().color = new Color32(255, 255, 225, 153);
        }
        else
        {
            town_center_button.GetComponent<Button>().interactable = true;
        }
    }
    
}
