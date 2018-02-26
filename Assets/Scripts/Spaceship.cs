using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class SpaceShip : MonoBehaviour {

    // メンバ変数の宣言
    public float Speed;
    public float ShotDelay;
    public bool CanShot;

    // ゲームオブジェクトにBulletコンポーネントを追加するためにGameObject型の変数Bulletを宣言
    public GameObject Bullet;

    // ゲームオブジェクトにExplosionコンポーネントを追加
    public GameObject explosion;

    // 爆発するメソッドExplosionを宣言
    public void Explosion() {
        
        // 爆発を作成する
        Instantiate(explosion, transform.position, transform.rotation);
    }

    // 弾を作成するメソッドShotの宣言
    public void Shot (Transform origin)
    {
        // オブジェクトBulletを生成する
        Instantiate(Bullet, origin.position, origin.rotation);
    }

    // 機体を移動するメソッドMove
    public void Move (Vector2 direction)
    {
        // Rigidbody2Dを取得、設定された方向に移動
        GetComponent<Rigidbody2D>().velocity = direction * Speed;
    }

    // 
    void Start () {
		
	}
	
	// 
	void Update () {
		
	}
}
