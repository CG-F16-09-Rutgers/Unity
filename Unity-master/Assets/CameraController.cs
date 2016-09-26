using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	bool camEnabled;
	// Use this for initialization
	void Start () {
		camEnabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (camEnabled) {
			int hori = 0;
			int vert = 0;
			if (Input.GetKey (KeyCode.A))
				hori--;
			if (Input.GetKey (KeyCode.D))
				hori++;
			if (Input.GetKey (KeyCode.W))
				vert++;
			if (Input.GetKey (KeyCode.S))
				vert--;
			transform.Translate (Vector3.right * hori * 0.1f);
			transform.Translate (Vector3.forward * vert * 0.1f);
			if (Input.GetKey (KeyCode.LeftShift))
				transform.Translate (Vector3.up * 0.1f);
			if (Input.GetKey (KeyCode.LeftControl))
				transform.Translate (-Vector3.up * 0.1f);
			float rotationx = Input.GetAxis ("Mouse X") + transform.localEulerAngles.y;
			float rotationy = Input.GetAxis ("Mouse Y") - transform.localEulerAngles.x;
			if (rotationy < -180)
				rotationy = rotationy + 360;
			rotationy = Mathf.Clamp (rotationy, -90f, 90f);
			transform.localEulerAngles = new Vector3 (-rotationy, rotationx, 0);
			if (Input.GetKeyDown (KeyCode.F))
				camEnabled = false;
		} else {
			if (Input.GetKeyDown (KeyCode.F))
				camEnabled = true;
		}
	
	}
}
