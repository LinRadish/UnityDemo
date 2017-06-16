using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
	//Text
	public GameObject talkPanel;
	public GameObject hpPanel;
	public Slider m_Blood;
	public Text m_text;
	private int i=0;

	private ChuanSong m_chuanSong;

	private RemCtrl m_Rem;
	private Transform player;//Rem'transform
	private float rotSpeed=0.5f;//move speed

	private Vector3 vc;
	private float life = 20f;
	public GameObject blood;
	public GameObject m_attack;//毒气攻击
	private bool showBoss = false;//Boss appear
	private bool bossBB=false;//Boss Talk 
	//schedule
	public float rateTime=4.0f;
	private float myTime;
	// Use this for initialization
	void Start () {
		m_chuanSong = FindObjectOfType<ChuanSong> ();
		m_Rem = FindObjectOfType<RemCtrl> ();
		player = m_Rem.transform;
	}

	// Update is called once per frame
	void Update () {
		m_Blood.value =life;
		transform.LookAt (player);
		if (showBoss == false)
			return;
		if (Vector3.Distance (player.position, transform.position) < 100 && bossBB == true) {
			talkPanel.SetActive (true);
			m_Rem.m_Move =false;
			m_text.text="大罪司教：我在这等你很久了！";
			hpPanel.SetActive (true);
			if (Input.GetMouseButtonUp (0)) {
				i++;
				if (i == 2) {
					talkPanel.SetActive (false);
					m_Rem.m_Move = true;
					bossBB = false;
				}
			}
		}
		if (Vector3.Distance (player.position, transform.position) < 100 && bossBB == false) {
			//每四秒生成一次毒气攻击
			myTime += Time.deltaTime;
			if (myTime > rateTime) {
				Vector3 attackPos = new Vector3 (transform.position.x, 2.5f, transform.position.z+2.0f);
				Instantiate (m_attack,attackPos,transform.rotation);
				myTime -= rateTime;
			}
			Vector3 targetDir = player.position - transform.position;
			float step = rotSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);
			//lookAt Rem
			transform.rotation = Quaternion.LookRotation (newDir);
			//follow Rem
			transform.Translate (Vector3.forward * Time.deltaTime * 10);
		}
	}

	//boss appear,set position
	public void setBoss(){
		Vector3 newPos = new Vector3 (123,transform.position.y, 495);
		transform.position = newPos;
		showBoss = true;
		bossBB = true;
	}
	void OnTriggerEnter(Collider coll){
		//when be hitted,this F have to destory
		if (coll.tag == "chain") {
			life -= 1f;
			if (life <= 0) {
				Destroy (gameObject);
				hpPanel.SetActive (false);
				//blood
				Instantiate (blood, transform.position, Quaternion.identity);
				m_chuanSong.setChuanSong ();
			}
			transform.Translate (Vector3.back *20);
		}
		//hit Rem,Rem's ph have to reduce 1
		if (coll.tag == "Rem") {
			m_Rem.m_life -= 5;
		}
	}
}
