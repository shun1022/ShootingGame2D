using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour {

    // このコライダーに接触してから離れたときに呼びだされるメソッド
    private void OnTriggerExit2D(Collider2D c)
    {
        // 弾を削除する
        Destroy(c.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
