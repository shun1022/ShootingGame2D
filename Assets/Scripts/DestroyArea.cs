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

}
