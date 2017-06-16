using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuanSong : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Rem") {
			Application.LoadLevel ("Test");
		}
	}
	public void setChuanSong(){
		Vector3 newPos = new Vector3 (369, transform.position.y, 462);
		gameObject.transform.position = newPos;
	}
}
