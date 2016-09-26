using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DirectorScript : MonoBehaviour {
	public Camera thecamera;
	private RaycastHit hit;
	private List<AgentScript> agents;
	public Vector3 target;
	int i;
	private bool found;
	private BallController currBall;
	private bool ballSelected;
	public Material ball1;
	public Material ball2;
	public Material agent1;
	public Material agent2;
	public Text helptext;

	// Use this for initialization
	void Start () {
		agents = new List<AgentScript>();
		found = false;
		ballSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = thecamera.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				print (hit.collider.name + " " + hit.collider.tag);
				if (hit.collider.CompareTag ("agent")) {
					foreach (AgentScript ag in agents) {
						if (ag.aindex == hit.collider.GetComponent<AgentScript> ().aindex) {
							agents[i].GetComponent<Renderer>().material = agent1;
							agents.RemoveAt (i);
							found = true;
							break;
						}
						i = i + 1;
					}

					if (found == false) {
						hit.collider.GetComponent<AgentScript> ().GetComponent<Renderer> ().material = agent2;
						agents.Add (hit.collider.GetComponent<AgentScript>());
					}
					found = false;
					i = 0;
				}
				else if (hit.collider.CompareTag("ball")){
					if(ballSelected){
						currBall.canMove = false;
						currBall.GetComponent<Renderer>().material = ball1;
						if(currBall == hit.collider.GetComponent<BallController>()){
							ballSelected = false;
							return;
						}
					}
					currBall = hit.collider.GetComponent<BallController>();
					currBall.canMove = true;
					ballSelected = true;
					currBall.GetComponent<Renderer>().material = ball2;

				}
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			Ray ray = thecamera.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray, out hit)){
				//if(!hit.collider.CompareTag("wall")){
					foreach (AgentScript ag in agents) {
						ag.target = hit.point;
					}
				//}
			}
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			foreach (AgentScript ag in agents)
				ag.GetComponent<Renderer>().material = agent1;
			agents.Clear ();
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			if (helptext.enabled)
				helptext.enabled = false;
			else
				helptext.enabled = true;
		}
	}
}
