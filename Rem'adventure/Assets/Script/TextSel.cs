using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSel : MonoBehaviour {
	//m_CM.Move   当进入对话时,主角不可移动
	private RemCtrl m_CM;

	//是否开始对话
	private bool isTalk=false;
	//对话索引
	private int index = 1;
	private int lastLine=0;

	//主线任务判定
	private bool m_mission=false;

	//对话框
	public GameObject talkPanel;
	public Text m_text;


	//NPC对话
	private string[] NPC_text;
	private string []Huke={"","Huke:","Rem,好久不见","我有点忙","不和你说了！"};
	private string []Lancecl={"","Lancecl:","他们都不和我玩"};
	private string []Catelyn={"","Catelyn:","Rem,你来啦","外面危险,你早点回去吧","再见"};
	private string []Shae={"","Shae:","Rem，你来啦","需要点什么吗？","好的,再见！"};
	private string []Cersei={"","Cersei:","你好，Rem","希望外面那些狼不会进村子","我很担心"};
	private string []Hodor={"","Hodor:","Rem,一会要我保护你回去吗？","哈哈哈哈,开玩笑的","你那么厉害！"};
	private string []Snow={"","Snow:","Rem，你好","我正在守卫，怕狼进村子里来","你来了我就可以稍稍休息一下了！"};
	private string []Rickard={"","Rickard:","Rem，你好","我还有好多活要干","再见！"};
	private string []Myrcella={"","Myrcella:","担惊受怕也不是个事","活还是得干","那群孩子整天乱跑"};
	private string []Varys={"","Varys:","..."};
	private string []Joffery={"","Joffery:","Rem，需要点什么","你自己拿吧！"};
	private string []Benjen={"","Benjen:","上帝保佑我们","希望恶魔们快点离开","永远不要再出现了！"};
	private string []Renly={"","Renly:","哎,我这个老头子是帮不上什么忙了","希望他们永远不要进入村庄就好了","哎！"};
	private string []Tywin={"","Tywin:","Rem,你能不能去找一找Araya","外面很危险","我们害怕","谢谢你,Rem"};

	void Start () {
		m_CM = FindObjectOfType<RemCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isTalk == false)
			return;
		if (index < lastLine) {
			m_text.text =NPC_text[1]+NPC_text[index];
			if (Input.GetMouseButtonDown(0)) {
				index++;
			}
		}
		if (index >= lastLine) {
			isTalk = false;
			index = 1;
			talkPanel.SetActive (false);
			m_CM.m_Move = true;
		}
	}
	//对话选择函数
	public void showText(string m_NPC){
		m_CM.m_Move = false;
		talkPanel.SetActive (true);
		switch(m_NPC){
		case "Huke":
			{
				NPC_text =Huke;
				lastLine = 5;
				isTalk = true;
			}
			break;
		case "Tywin":
			{
				NPC_text = Tywin;
				if (m_mission == false) {
					index = 1;
					lastLine = 5;
					isTalk = true;
				} else {
					index = 4;
					lastLine = 6;
					isTalk = true;
				}
			}
			break;
		case "Lancecl":
			{
				NPC_text = Lancecl;
				lastLine = 3;
				isTalk = true;
			}
			break;
		case "Catelyn":
			{
				NPC_text = Catelyn;
				lastLine = 5;
				isTalk = true;
			}
			break;
		case "Shae":
			{
				NPC_text = Shae;
				lastLine = 5;
				isTalk = true;
			}
			break;
		case "Cersei":
			{
				NPC_text = Cersei;
				lastLine = 5;
				isTalk = true;
			}
			break;
		case "Hodor":
			{
				NPC_text = Hodor;
				lastLine = 5;
				isTalk = true;
			}
			break;
		case "Snow":
			{
				NPC_text = Snow;
				lastLine = 5;
				isTalk = true;
			}
			break;
		case "Rickard":
			{
				NPC_text = Rickard;
				lastLine = 5;
				isTalk = true;
			}
			break;
		case "Myrcella":
			{
				NPC_text = Myrcella;
				lastLine = 5;
				isTalk = true;
			}
			break;
		case "Varys":
			{
				NPC_text = Varys;
				lastLine = 3;
				isTalk = true;
			}
			break;
		case "Joffery":
			{
				NPC_text = Joffery;
				lastLine = 4;
				isTalk = true;
			}
			break;
		case "Benjen":
			{
				NPC_text = Benjen;
				lastLine = 5;
				isTalk = true;
			}
			break;
		case "Renly":
			{
				NPC_text = Renly;
				lastLine = 5;
				isTalk = true;
			}
			break;
		default:
			break;
		}
	}
}
