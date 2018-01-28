using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	//スクロール速度
	private float scrollspeed =-0.03f;
	//背景終了位置
	private float deadline =-25;
	//背景開始位置
	private float startLine =50f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//背景を移動する
		transform.Translate(this.scrollspeed,0,0);

		//画面外に出たら、画面右端に移動する
		if (transform.position.x < this.deadline) {
			transform.position = new Vector2 (this.startLine, 1);
		}
	}
}
