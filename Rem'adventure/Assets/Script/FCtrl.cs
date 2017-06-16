using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCtrl : MonoBehaviour {
	private Transform player;
	public float rotSpeed=0.5f;
	public Vector3 vc;
	public int flag=0;
	public GameObject blood;
	public RemCtrl m_Rem;

	// Use this for initialization
	void Start () {
		player = FFFWall.lm.player;
		m_Rem = FindObjectOfType<RemCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetDir = player.position - transform.position;
		float step = rotSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);
		//F will always lookAt Rem
		transform.rotation = Quaternion.LookRotation (newDir);
		//F will follow with Rem
		transform.Translate (Vector3.forward * Time.deltaTime * 15);
	}

	void OnTriggerEnter(Collider coll){
		//when be hitted,this F have to destory
		if (coll.tag == "chain") {
				transform.Translate (Vector3.back* Time.deltaTime * 150);
				Destroy (gameObject);
			//blood
				Instantiate (blood, transform.position, Quaternion.identity);
		}
		//hit Rem,Rem's ph have to reduce 1
		if (coll.tag == "Rem") {
			m_Rem.m_life -= 1;
		}
	}
}
