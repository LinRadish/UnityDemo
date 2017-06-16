using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour {
	private Rigidbody m_Rigibody;
	private RemCtrl m_Rem;
	// Use this for initialization
	void Start () {
		m_Rigibody = gameObject.GetComponent<Rigidbody> ();
		m_Rem = FindObjectOfType<RemCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_Rem.m_Move == false)
			return;
		if (Input.GetMouseButtonUp (1)) {
			m_Rigibody.AddForce (Vector3.forward * 10000);
		}
	}
}
