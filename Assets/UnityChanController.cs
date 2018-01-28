using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

	//アニメーションするためのコンポーネントを入れる
	Animator animator;

	//Unityちゃんを移動させるコンポーネントを容れる
	Rigidbody2D rigid2D;

	//地面の位置
	private float groundlevel = -3.0f;

	//ジャンプの速度の減衰
	private float dump = 0.8f;

	//ジャンプの速度
	float jumpVelocity =20;

	//Unityちゃんが前に行く
	float uspeed = 0.01f;

	//ゲームオーバーになる位置
	private float deadline = -9;

	//走ってる？
	public bool IsRunning = true;


	// Use this for initialization
	void Start () {

		//アニメータのコンポーネントを取得する
		this.animator = GetComponent<Animator>();
		//Rigidbody2Dのコンポーネントを取得する
		this.rigid2D = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		//Unityちゃんを移動させる
		transform.Translate (this.uspeed, 0, 0);

		//走るアニメーションを再生するためにAnimatorのバランスを調整する
		this.animator.SetFloat("Horizontal",1);

		//着地しているかどうかを調べる
		IsRunning = (transform.position.y>this.groundlevel)? false:true;
		this.animator.SetBool ("isGround", IsRunning);

		//ジャンプ状態のときはボリュームを0にする。
		GetComponent<AudioSource>().volume = (IsRunning)? 1:0;

//		Debug.Log(isGround);
//		Debug.Log("ジャンプ速度"+this.rigid2D.velocity);

		//着地状態でクリックされた場合
		if (Input.GetMouseButtonDown (0) && IsRunning) {
			//上方向の力をかける
			this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);
		}

		//クリックをやめたら上方向への力を減衰する
		if (Input.GetMouseButtonDown(0)==false){
			if(this.rigid2D.velocity.y >0){
				this.rigid2D.velocity *= this.dump;
			}
		}

		//デッドラインを超えた場合ゲームオーバーにする
		if (transform.position.x < this.deadline) {
			//UIControllerのGameOver関数を呼び出して画面上に「GAMEOVER」と表示する
			GameObject.Find ("Canvas").GetComponent<UIController> ().Gameover ();

			//Unityちゃんを破棄する
			Destroy (gameObject);
		}
	}
}