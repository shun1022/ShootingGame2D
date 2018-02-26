using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    // アニメーションの終了時に呼び出されるメソッド
    void OnAnimationFinish ()
    {
        // Explosionオブジェクトの削除
        Destroy(gameObject);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
