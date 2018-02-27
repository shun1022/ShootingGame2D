using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    // スクロールするスピードを設定するメンバ変数
    public float Speed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // 時間によってローカル変数Yが０から１に変化する、１になったらまた０になる
        float Y = Mathf.Repeat(Time.time * Speed, 1);

        // Yの値がずれていくオフセットを作成
        Vector2 offset = new Vector2(0, Y);

        // マテリアルにオフセットを設定する
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
	}
}
