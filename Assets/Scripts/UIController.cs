using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;

public class UIController : MonoBehaviour {

    public GameObject ui_canvas;
    public GameObject build_ui_panel;
    public GameObject place_cancel_Panel;
    public GameObject beginner_canvas;
    public GameObject build_ui_button;

    private void Start()
    {
        ui_canvas.SetActive(false);
        build_ui_panel.SetActive(false);
        place_cancel_Panel.SetActive(false);
    }

    private void Update()
    {
        if (GridTracker.GetEntityCount(Entities.GRASS) == 20)
        {
            ui_canvas.SetActive(true);
            beginner_canvas.SetActive(false);
        }

        if (PlacementScript.isAnObjectSelected == true)
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
    }
    
}
