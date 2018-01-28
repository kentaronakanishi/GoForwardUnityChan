using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	//ゲームオーバーテキスト
	private GameObject gameOverText;

	//走行距離テキスト
	private GameObject runLengthText;

	//Unityちゃん
	private GameObject Unitychan;
	private float unityy;

	//走った距離
	private float len =0;

	//走る速度
	private float speed =0.03f;

	//ゲームオーバーの判定
	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		//シーンビューからオブジェクトの実体を検索する
		this.gameOverText = GameObject.Find("GameOver");
		this.runLengthText = GameObject.Find ("RunLength");
		this.Unitychan = GameObject.Find("UnityChan2D");
	}
	
	// Update is called once per frame
	void Update () {

		if (this.isGameOver == false) {
            //Unityちゃんが地面を走っているかどうかを検出
            unityy = Unitychan.transform.position.y;
            //if(Unitychan.IsRunning == true){
            if (unityy < -3) {
				//走った距離を更新する
				this.len += this.speed;
			}
		
			//走った距離を表示する
			this.runLengthText.GetComponent<Text> ().text = "Distance:   " + len.ToString ("F2") + "m";				
		}

		//ゲームオーバーになった場合
		if (this.isGameOver) {
			Debug.Log ("クリックでリトライ");
			//クリックされたらシーンをロードする
			if (Input.GetMouseButtonDown (0)) {
				//GameSceneを読み込む
				SceneManager.LoadScene ("GameScene");
			}
		}
	}

	public void Gameover(){
		//ゲームオーバーになった時に、画面上にゲームオーバーを表示する
		this.gameOverText.GetComponent<Text>().text = "GameOver";
		this.isGameOver = true;
		Debug.Log (isGameOver);
		//クリックされたらシーンをロードする
	}
}