using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour {

	public void Awake(){
		Invoke ("DesSelf",2);
	}
	public void DesSelf(){
		Destroy (gameObject);
	}
}
