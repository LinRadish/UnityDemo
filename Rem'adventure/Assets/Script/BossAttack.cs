using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {
	private RemCtrl m_Rem;
	private Transform player;
	private float rotSpeed=1f;

	private float rateTime=10.0f;
	private float myTime;
	// Use this for initialization
	void Start () {
		m_Rem = FindObjectOfType<RemCtrl> ();
		player = m_Rem.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetDir = player.position - transform.position;
		float step = rotSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.Translate (Vector3.forward * Time.deltaTime * 15);
		//生成毒气10秒后没有攻击到主角会自动消失
		myTime += Time.deltaTime;
		if (myTime > rateTime) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter(Collider coll){		//when be hitted,this F have to destory
		//hit Rem,Rem's ph have to reduce 1
		if (coll.tag == "Rem") {
			m_Rem.m_life -= 3;
			Destroy (gameObject);
		}
	}
}
