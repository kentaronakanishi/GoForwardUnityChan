using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	//キューブの移動速度
	private float speed =-0.2f;

	//消滅位置
	private float deadLine =-10;

	//SE
	AudioSource SE;


	// Use this for initialization
	void Start () {
		//SEのコンポーネントを入れる
		this.SE = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		//キューブを移動させる
		transform.Translate (this.speed, 0, 0);
		//transform.Position.Vector3 (this.speed, 0, 0);

		//画面外に出たら破棄する
		if (transform.position.x < this.deadLine) {
			Destroy (gameObject);
		
		}
	}

	//コリジョンモードで他のオブジェクトと接触した場合の処理
	void OnCollisionEnter2D(Collider2D other){

		//障害物に衝突した場合
//		if (other.tag == "SoudObject") {
			//衝突判定
			Debug.Log("衝突");

			//音を出す。
//			SE.Play();
//		}
	}
}
