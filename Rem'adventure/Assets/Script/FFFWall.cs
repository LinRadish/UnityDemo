using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFFWall : MonoBehaviour {
	static public FFFWall lm;
	public Transform player;
	public GameObject enemy;
	public bool enemyCtrl=false;
	//怪物生成时间
	public float rateTime=2.0f;
	float myTime;
	int num=0;
	// 初始化
	void Awake () {
		lm = this;
	}
	void Update(){
		if (enemyCtrl) {
			myTime += Time.deltaTime;
			if (myTime>rateTime) {
				//刷怪位置
				Vector2 r = Random.insideUnitCircle.normalized * 20;//世界坐标中心半径10
				Instantiate (enemy, player.position + new Vector3 (r.x, 0, r.y), Quaternion.Euler (new Vector3 (0, Random.Range (0.0f, 360.0f), 0)));
				myTime -= rateTime;
				num++;
			} 
			if(num>10){
				enemyCtrl = false;
				Destroy (gameObject);
			}
		}
	}
	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Rem") {
			enemyCtrl = true;
		}
	}
}
