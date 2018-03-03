using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // メンバ変数
    public int Speed = 10;

    // メンバ変数
    public float LifeTime = 5;

    // メンバ変数
    public int Power = 1;

	// 最初に一度だけ呼び出されるメソッドStart
	void Start () {
        // Rigidbody2Dを取得、速度Speedで移動する
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * Speed;

        // LifeTime杪後に削除
        Destroy(gameObject, LifeTime);
	}
	
}
