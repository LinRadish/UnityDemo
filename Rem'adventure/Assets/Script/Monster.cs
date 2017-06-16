using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
	private RemCtrl m_Rem;
	private Transform player;//Rem's transform

	//move speed
	private float rotSpeed=0.5f;
	private Vector3 vc;

	//life
	private float life = 5f;
	public GameObject blood;
	private Animation m_Anim;

	// Use this for initialization
	void Start () {
		m_Rem = FindObjectOfType<RemCtrl> ();
		player = m_Rem.transform;
		m_Anim = gameObject.GetComponent<Animation> ();
	}

	// Update is called once per frame
	void Update () {
		if (m_Rem.m_Move == false)
			return;

		//when the distance bettwen Rem and this monster smaller than 100,monster turn to Rem
		if (Vector3.Distance (player.position, transform.position) < 100) {
			transform.LookAt (player);
			m_Anim.Play ("blank");
		}

		if (Vector3.Distance (player.position, transform.position) > 30)
			return;
		//when the distance bettwen Rem and this monster smaller than 30,monster start to attack Rem
		Vector3 targetDir = player.position - transform.position;
		float step = rotSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);
		transform.rotation = Quaternion.LookRotation (newDir);
		//Monsters will always follow with Rem
		transform.Translate (Vector3.forward * Time.deltaTime * 15);
	}

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "chain") {
			life -= 1f;
			if (life <= 0) {
				Destroy (gameObject);
				Instantiate (blood, transform.position, Quaternion.identity);//blood
			}
			transform.Translate (Vector3.back *15);
		}
		//hit Rem,Rem's ph have to reduce 1
		if (coll.tag == "Rem") {
			m_Rem.m_life -= 1;
		}
	}
}
