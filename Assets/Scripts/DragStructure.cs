using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragStructure : MonoBehaviour {

	private Vector3 mOffset;
    private Vector2 mousePos;

    void OnMouseDown() {
		mOffset = gameObject.transform.position - GetMouseWorldPos ();
	}

	private Vector3 GetMouseWorldPos() {
		Vector2 mousePoint = Input.mousePosition;

		return Camera.main.ScreenToWorldPoint (mousePoint);
	}

	void OnMouseDrag() {
        mousePos = GetMouseWorldPos() + mOffset;
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
        
        //         transform.position = GetMouseWorldPos() + mOffset;
    }

}
