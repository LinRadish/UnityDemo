using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Ctrl : MonoBehaviour {
	public bool appear = false;
	public bool findDog = false;
	private AryaText m_arya;
	private Angtrl m_ang;
	// Use this for initialization
	void Start () {
		m_ang = FindObjectOfType<Angtrl> ();
		m_arya = FindObjectOfType<AryaText> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (appear == true) {
			Vector3 newPos = new Vector3 (198, transform.position.y, 337);
			//Vector3 newPos = new Vector3 (178, transform.position.y,113);
			gameObject.transform.position = newPos;
		}
		if (findDog == true) {
			m_ang.Ang_mission = true;
			m_arya.Arya_mission = true;
			Vector3 newPos = new Vector3 (260, transform.position.y, 599);
			gameObject.transform.position = newPos;
		}
	}
}
