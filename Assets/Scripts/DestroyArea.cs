using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour {

    // このコライダーに接触してから離れたときに呼びだされるメソッド
    private void OnTriggerExit2D(Collider2D C)
    {
        // 弾を削除する
        Destroy(C.gameObject);
    }

    void Start()
    {
        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // サイズを求める
        Vector2 size = max * 2;

        // 当たり判定のサイズを変更
        GetComponent<BoxCollider2D>().size = size;
    }
}
