using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour {
	
	//gameStart control
	public GameObject StartPanel;
	public GameObject HelpPanel;
	public GameObject BookPanel;
	public bool gameStart = false;

	//gameOver  UI control
	public GameObject EndPanel;
	public bool gameOver=false;

	//Rem'blood control
	public GameObject bloodPanel;
	public Slider m_Blood;

	//NPC TalkPanel control
	public GameObject talkPanel;

	//Game help book
	private int index=0;
	public Image helpImage;
	public Sprite[] m_help;

	private RemCtrl m_CM;
	private Angtrl m_Angtrl;

	// Use this for initialization
	void Start () {
		m_Angtrl = FindObjectOfType<Angtrl> ();
		StartPanel.SetActive (true);
		EndPanel.SetActive (false);
		bloodPanel.SetActive (false);
		talkPanel.SetActive (false);

		m_CM = FindObjectOfType<RemCtrl> ();
	}
	
	//Update is called once per frame
	void Update () {
		if (gameStart == false)
			return;
		else
			m_Blood.value = m_CM.m_life;
		if (m_CM.m_life <= 0) {
			m_CM.m_life = 0;
			m_CM.m_Move = false;
			gameOver = true;
			EndPanel.SetActive (true);
		}
	}
	//游戏结束界面按钮回调函数
	public void EndGame(){
		Application.LoadLevel ("Test02");//Dead,Restart the game
	}
	//游戏开始界面开始游戏按钮回调函数
	public void StartGame(){
		StartPanel.SetActive (false);
		gameStart = true;
		//Carton end,start move
		m_CM.m_Move= true;
		StartPanel.SetActive (false);
		bloodPanel.SetActive (true);
		m_Angtrl.doMission();
	}
	public void HelpClick(){
		HelpPanel.SetActive (true);
	}
	//游戏开始界面帮助按钮返回回调函数
	public void HelpReturn(){
		HelpPanel.SetActive (false);
	}
	//游戏界面帮助按钮回调函数
	public void HelpBook(){
		m_CM.m_Move = false;
		BookPanel.SetActive (true);
	}
	//游戏帮助界面按钮回调函数
	public void BookReturn(){
		m_CM.m_Move = true;
		BookPanel.SetActive (false);
	}
	//游戏帮助界面下一页按钮回调函数
	public void addIndex(){
		index++;
		if (index >= 8)
			index = 8;
		helpImage.GetComponent<Image>().sprite = m_help [index];
	}
	//游戏帮助界面上一页按钮回调函数
	public void subIndex(){
		index--;
		if (index <= 0)
			index = 0;
		helpImage.GetComponent<Image>().sprite = m_help [index];
	}
}
