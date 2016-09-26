using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float moveTime;
	public float myx, myy, myz;
	private int dir;
	private bool switched;
	void Start(){
		dir = -1;
		switched = false;
	}
	// Update is called once per frame

	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
		if (((int)Time.fixedTime) % moveTime != 0) {
			Vector3 go = (new Vector3(myx, myy, myz))*dir*0.01f;
			transform.Translate (go, Space.World);
			Debug.Log (go);
			switched = false;
		} else if(switched == false){
			dir = dir * (-1);
			switched = true;
		}

	}
}
