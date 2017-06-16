using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	private RemCtrl m_Rem;
	// Use this for initialization
	void Start () {
		m_Rem = FindObjectOfType<RemCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {
		//NPC always look at Rem
		transform.LookAt (m_Rem.transform);
	}
}
