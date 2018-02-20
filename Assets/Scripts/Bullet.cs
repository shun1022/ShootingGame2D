using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // メンバ変数
    public int Speed = 10;

	// Use this for initialization
	void Start () {
        // Rigidbody2Dを取得、速度Speedで移動する
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * Speed;
	}
	
}
