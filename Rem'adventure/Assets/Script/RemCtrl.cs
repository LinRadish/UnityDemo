using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemCtrl : MonoBehaviour {
	//Rem Move
	private CharacterController m_CC;
	private float m_KeyStrokeMoveStep=10f;//Speed
	private Vector3 m_MoveDir;//Direction
	private Quaternion m_Rot;//Rotation

	//Game Control
	private GameCtrl m_Ctrl;

	//Can Rem move?
	public bool m_Move;

	//Rem PH
	public float m_life=100f;

	//Camera Control
	private float sensitivityX = 5F;//Direction sensitivity     
	private float rotationY = 0F;  

	// Use this for initialization
	void Start () {
		m_CC = gameObject.GetComponent<CharacterController> ();
		m_Move =false;
		m_Ctrl = FindObjectOfType<GameCtrl> ();

	}
	
	// Update is called once per frame
	void Update () {
		//if the game didn't start,just return 
		if (m_Ctrl.gameStart == false)
			return;

		//when talk with other,Rem can't move
		if (m_Move == false) return;

		if (Input.GetMouseButton(0))  
		{  
			//根据鼠标移动的快慢(增量) 
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;  
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);  
		}  

		Vector3 v_Dir = Vector3.zero;
		if (Input.GetKey (KeyCode.W)) {
			v_Dir.z += m_KeyStrokeMoveStep;
		}
		if (Input.GetKey (KeyCode.S)) {
			v_Dir.z -= m_KeyStrokeMoveStep;
		}

		m_MoveDir =transform.rotation * v_Dir;
		m_CC.SimpleMove(m_MoveDir);
	}
}
