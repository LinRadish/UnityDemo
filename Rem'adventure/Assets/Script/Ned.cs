using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ned : MonoBehaviour {
	//Mission UI over the head
	public Image m_missionBox;
	public Sprite m_tan;
	public Sprite m_Wen;
	public Sprite m_htan;

	private RemCtrl m_CM;

	//对话框
	public GameObject talkPanel;
	public Text m_text;
	private int index=1;
	private int lastLine=0;

	private bran m_bran;
	public bool Ned_mission=false;
	private bool Ned_talk=false;
	private string []m_Ned={"","Ned:","你好呀,Rem","Araya那小子不知道哪去了","你要是看到他就帮我喊他回来","Rem，谢谢你帮我找到小狗和Araya！"};

	void Start(){
		m_CM = FindObjectOfType<RemCtrl> ();
		m_bran = FindObjectOfType<bran> ();
	}
	void Update () {
		transform.LookAt (m_CM.transform);
		if (Ned_talk == false)
			return;
		if (index < lastLine) {
			m_text.text =m_Ned[1]+m_Ned[index];
			if (Input.GetMouseButtonDown(0)) {
				index++;
			}
		}
		if (index >= lastLine) {
			if (index == 5) {
				setMissionBox (1);
				m_bran.startBranMission = true;
			}
			if (index == 6) {
				setMissionBox (2);
			}
			Ned_talk = false;
			index = 1;
			talkPanel.SetActive (false);
			m_CM.m_Move = true;
		}
	}

	//UI Control
	private void setMissionBox(int n){
		switch (n) {
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

	//任务设置,包括UI和对话
	public void DoMission(){
		if (Ned_mission == false) {
			m_CM.m_Move = false;
			talkPanel.SetActive (true);
			index = 1;
			lastLine = 5;
			Ned_talk = true;

		}
		if (Ned_mission == true) {
			m_CM.m_Move = false;
			talkPanel.SetActive (true);
			index = 4;
			lastLine = 6;
			Ned_talk = true;
		}

	}
}
