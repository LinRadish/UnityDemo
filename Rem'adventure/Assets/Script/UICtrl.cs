using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//世界空间内的UI始终朝向摄像机
		transform.rotation = Camera.main.transform.rotation;
	}
}
