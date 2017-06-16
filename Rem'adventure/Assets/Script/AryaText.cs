using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AryaText : MonoBehaviour {
	public Image m_missionBox;
	public Sprite m_tan;
	public Sprite m_Wen;
	public Sprite m_htan;
	private RemCtrl m_CM;
	public GameObject talkPanel;
	public Text m_text;

	private Angtrl m_Ang;
	private Ned m_Ned;
	private bran m_bran;
	public GameObject AryaUI;
	public bool startAryaMission=false;
	private bool Arya_talk=false;
	public bool Arya_mission=false;
	private int index=1;
	private int lastLine=0;
	private string []m_Arya={"","Arya:","Rem,我的小狗不见了，/(ㄒoㄒ)/~~","找到小狗我就回去/(ㄒoㄒ)/~~","你要帮我找吗！？o(*￣▽￣*)o",
		"但是你千万别去小树林，那儿很危险！","我在这等着你回来。","你找到我的小狗了吗？","真是太感谢你了","那我们回去吧，他们应该等急了。"};
	void Start(){
		m_Ang = FindObjectOfType<Angtrl> ();
		m_CM = FindObjectOfType<RemCtrl> ();
		m_Ned = FindObjectOfType<Ned> ();
		m_bran = FindObjectOfType<bran> ();
	}
	void Update () {
		transform.LookAt (m_CM.transform);
		if (startAryaMission == true) {
			setArya ();
		}
		if (Arya_talk == false)
			return;
		if (index < lastLine) {
			m_text.text =m_Arya[1]+m_Arya[index];
			if (Input.GetMouseButtonDown(0)) {
				index++;
			}
		}
		if (index >= lastLine) {
			if (index == 6) {
				setMissionBox (1);
				m_bran.Bran_mission = true;
				m_Ned.Ned_mission = true;
				m_Ang.StartAngMission = true;
			}
			if (index == 9) {
				setMissionBox (2);
			}
			Arya_talk = false;
			index = 1;
			talkPanel.SetActive (false);
			m_CM.m_Move = true;
		}
	}
	private void setMissionBox(int n){
		switch (n) {
		case 0:
			{
				Vector3 newPos =new Vector3 (260,transform.position.y,641);
				gameObject.transform.position = newPos;
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
	private void setArya(){
		Vector3 newPos =new Vector3 (260,transform.position.y,641);
		gameObject.transform.position = newPos;
	}
	public void DoMission(){
		if (Arya_mission == false) {
			m_CM.m_Move = false;
			talkPanel.SetActive (true);
			index = 1;
			lastLine = 6;
			Arya_talk = true;
		}
		else if (Arya_mission == true) {
			m_CM.m_Move = false;
			talkPanel.SetActive (true);
			index = 6;
			lastLine = 9;
			Arya_talk = true;
		}
	}
}
