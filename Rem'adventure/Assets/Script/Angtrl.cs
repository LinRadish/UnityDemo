using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angtrl : MonoBehaviour {
	public Image m_missionBox;
	public Sprite m_tan;
	public Sprite m_Wen;
	public Sprite m_htan;

	private RemCtrl m_CM;
	public GameObject UIPanel;
	public GameObject talkPanel;
	public Text m_text;
	private bool Ang_talk=false;
	private int index=1;
	private int lastLine = 0;
	private string []Ang={"","Ang:","Rem,我先去村子里等你,你快点来！","Rem,你来啦","小狗就在前面树林里","你找到小狗了吗,太好了！","快送回给Arya,然后我们就可以回城堡了！"};
	public bool StartAngMission=false;
	public bool Ang_mission = false;
	private Dog_Ctrl m_dog;
	private bool first=true;
	void Start(){
		m_CM = FindObjectOfType<RemCtrl> ();
		m_dog = FindObjectOfType<Dog_Ctrl> ();
	}
	void Update () {
		transform.LookAt (m_CM.transform);
		if (StartAngMission == true) {
			UIPanel.SetActive (true);
			setAng (1);
		}
		if (Ang_talk == false)
			return;
		if (index < lastLine) {
			m_text.text =Ang[1]+Ang[index];
			if (Input.GetMouseButtonDown(0)) {
				index++;
			}
		}
		if (index >= lastLine) {
			if (index == 3) {
				setAng (0);
			}
			if (index == 5) {
				setMissionBox (1);
				m_dog.appear = true;
			}
			if (index == 7) {
				setMissionBox (2);
				setAng (0);
			}
			Ang_talk = false;
			index = 1;
			talkPanel.SetActive (false);
			m_CM.m_Move = true;
		}
	}
	// Use this for initialization
	public void doMission(){
		if (first == true) {
			m_CM.m_Move = false;
			talkPanel.SetActive (true);
			index = 2;
			lastLine = 3;
			Ang_talk = true;
			first = false;
		} else {
			if (Ang_mission == false) {
				m_CM.m_Move = false;
				talkPanel.SetActive (true);
				index = 3;
				lastLine = 5;
				Ang_talk = true;
			} else {
				m_CM.m_Move = false;
				talkPanel.SetActive (true);
				index = 5;
				lastLine = 7;
				Ang_talk = true;
			}
		}
	}
	public void setAng(int n){
		switch (n) {
		case 0:
			{
				Vector3 newPos = new Vector3 (260, transform.position.y, 599);
				gameObject.transform.position = newPos;
			}
			break;
		case 1:
			{
				Vector3 newPos =new Vector3 (181,transform.position.y,590);
				gameObject.transform.position = newPos;
			}
			break;
		}
	}
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
}
