using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bran : MonoBehaviour {
	public Image m_missionBox;
	public Sprite m_tan;
	public Sprite m_Wen;
	public Sprite m_htan;
	private RemCtrl m_CM;
	public GameObject talkPanel;
	public Text m_text;

	private AryaText m_Arya;
	public GameObject BranUI;
	public bool startBranMission=false;
	private bool Bran_talk=false;
	public bool Bran_mission=false;
	private int index=1;
	private int lastLine=0;
	private string []m_Bran={"","Bran:","Ummm,Rem!","Rem,Araya的小狗走丢了,他去找了","我也不知道他去哪找","外面跟危险我们也很担心","Rem，你找到Araya啦，真是太好了！"};
	void Start(){
		m_CM = FindObjectOfType<RemCtrl> ();
		m_Arya = FindObjectOfType<AryaText> ();
		//BranUI.SetActive (false);
	}
	void Update () {
		transform.LookAt (m_CM.transform);
		if (startBranMission == true) {
			setMissionBox (0);
		}
		if (Bran_talk == false)
			return;
		if (index < lastLine) {
			m_text.text =m_Bran[1]+m_Bran[index];
			if (Input.GetMouseButtonDown(0)) {
				index++;
			}
		}
		if (index >= lastLine) {
			if (index == 6) {
				setMissionBox (1);
				m_Arya.startAryaMission = true;
			}
			if (index == 7) {
				setMissionBox (2);
			}
			Bran_talk = false;
			index = 1;
			talkPanel.SetActive (false);
			m_CM.m_Move = true;
		}
	}
	private void setMissionBox(int n){
		switch (n) {
		case 0:
			{
				BranUI.SetActive (true);
			}
			break;
		case 1:
			{
				m_missionBox.GetComponent<Image> ().sprite = m_Wen;
			}
			break;
		case 2:
			{
				m_missionBox.GetComponent<Image> ().sprite = m_htan;
			}
			break;
		}
	}
	public void DoMission(){
		if (startBranMission == false) {
			m_CM.m_Move = false;
			talkPanel.SetActive (true);
			index = 1;
			lastLine = 3;
			Bran_talk = true;
		} else {
			if (Bran_mission == false) {
				m_CM.m_Move = false;
				talkPanel.SetActive (true);
				index = 2;
				lastLine = 6;
				Bran_talk = true;
			}
			if (Bran_mission == true) {
				m_CM.m_Move = false;
				talkPanel.SetActive (true);
				index = 5;
				lastLine = 7;
				Bran_talk = true;
			}
		}
	}
}
