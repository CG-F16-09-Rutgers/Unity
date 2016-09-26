using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	public Camera mainCamera;
	public bool canMove;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		canMove = false;
	}

	void Update(){
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}

	void FixedUpdate(){
		if (canMove) {
			//Vector3 moveHorizontal = Input.GetAxis ("Horizontal") * mainCamera.transform.right;
			//Vector3 moveVertical = Input.GetAxis ("Vertical") * mainCamera.transform.forward;
			int hori = 0;
			int vert = 0;
			if (Input.GetKey (KeyCode.LeftArrow))
				hori--;
			if (Input.GetKey (KeyCode.RightArrow))
				hori++;
			if (Input.GetKey (KeyCode.UpArrow))
				vert++;
			if (Input.GetKey (KeyCode.DownArrow))
				vert--;
		

			Vector3 movement = (mainCamera.transform.right * hori) + (mainCamera.transform.forward * vert);

			rb.AddForce (movement * speed);
		}
	}
}
