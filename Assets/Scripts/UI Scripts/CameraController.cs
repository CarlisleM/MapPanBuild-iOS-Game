using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 15f;	// Scroll speed
	public float panBorderThickness = 10f;	// Specify how close we get to the edge before the camera moves that direction
	public Vector2 panLimit;	// Stores x and y coordinate limits for scrolling

	public float scrollSpeed = 15f;
	public float minZ = 20f;
	public float maxZ = 120f;

	// Update is called once per frame
	void Update () {
		
		Vector3 pos = transform.position;

		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			pos.y += panSpeed * Time.deltaTime; // Smooth at any frame rate due to moving relative to time not frame rate
		}

		if (Input.GetKey ("s") || Input.mousePosition.y <= panBorderThickness) {
			pos.y -= panSpeed * Time.deltaTime; // Smooth at any frame rate due to moving relative to time not frame rate
		}

		if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
			pos.x += panSpeed * Time.deltaTime; // Smooth at any frame rate due to moving relative to time not frame rate
		}

		if (Input.GetKey ("a") || Input.mousePosition.x <= panBorderThickness) {
			pos.x -= panSpeed * Time.deltaTime; // Smooth at any frame rate due to moving relative to time not frame rate
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		pos.z += scroll * scrollSpeed * 100f * Time.deltaTime;

//		pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
//		pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
//		pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

		transform.position = pos;
	}
}
