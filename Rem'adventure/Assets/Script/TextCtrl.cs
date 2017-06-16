using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCtrl : MonoBehaviour {
	private RemCtrl m_CM;

	//对话框
	public GameObject m_TextBox;

	private TextSel m_TextSel;

	//NPC
	public Boss m_boss;
	private AryaText m_Arya;
	private Ned m_Ned;
	private Angtrl m_Angtrl;
	private bran m_bran;
	private Dog_Ctrl m_dog;
	// Use this for initialization
	void Start () {
		m_boss = FindObjectOfType<Boss> ();
		m_Angtrl = FindObjectOfType<Angtrl> ();
		m_Ned = FindObjectOfType<Ned> ();
		m_bran = FindObjectOfType<bran> ();
		m_Arya = FindObjectOfType<AryaText> ();
		m_CM = FindObjectOfType<RemCtrl> ();
		m_TextSel = FindObjectOfType<TextSel> ();
		m_dog = FindObjectOfType<Dog_Ctrl> ();

		//
		m_TextBox.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (m_CM.m_Move == false)
			return;
		Ray m_Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit m_Hit;
		if (Input.GetMouseButtonDown(0)&&Physics.Raycast (m_Ray, out m_Hit)) {
			if (Vector3.Distance (m_CM.transform.position, m_Hit.collider.gameObject.transform.position) > 10)
				return;
			//when the left-mousebutton is down,find what the tag is
			switch(m_Hit.collider.gameObject.tag){
			case "Lancecl":
			case "Catelyn":
			case "Shae":
			case "Cersei":
			case "Hodor":
			case "Snow":
			case "Rickard":
			case "Myrcella":
			case "Varys":
			case "Joffery":
			case "Benjen":
			case "Renly":
			case "Huke":
			case "Tywin":
				m_TextSel.showText (m_Hit.collider.gameObject.tag);//普通NPC调用TextSel中函数
				break;
			case "Arya":
				m_Arya.DoMission ();
				break;
			case "Bran":
				m_bran.DoMission ();
				break;
			case "Ned":
				m_Ned.DoMission ();
				break;
			case "Ang":
				m_Angtrl.doMission();
				break;
			case "dog":
				{
					m_dog.findDog = true;
					m_boss.setBoss ();
				}
				break;
			default:
				break;
			}
		}
	}
}
