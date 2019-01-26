using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject UICanvas;
    public GameObject BuildUIPanel;
    public GameObject PlaceCancelPanel;
    public GameObject BeginnerCanvas;
    public GameObject Blocker1;
    public GameObject Blocker2;

    private void Start()
    {
        UICanvas.SetActive(false);
        BuildUIPanel.SetActive(false);
        PlaceCancelPanel.SetActive(false);
    }

    private void Update()
    {
        if (GroundClass.groundCount == 20)
        {
            UICanvas.SetActive(true);
            BuildUIPanel.SetActive(true);
            BeginnerCanvas.SetActive(false);
            Blocker1.SetActive(false);
            Blocker2.SetActive(false);
        }
    }

}
