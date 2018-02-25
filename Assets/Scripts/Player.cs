using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // SpaceShipコンポーネントを追加
    SpaceShip SpaceShip;


        
    // コルーチンでStartメソッドを呼び出す
    IEnumerator Start () {
        
        // GetComponentでSpaceShipクラスのインスタンスを取得しローカル変数SpaceShipで保持
        SpaceShip = GetComponent<SpaceShip>();

        // 発射するたびにShotDelay秒中断し、再開する
        while (true) {
            SpaceShip.Shot(transform);
            yield return new WaitForSeconds(SpaceShip.ShotDelay);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        // GetAxisRawメソッドによりキーボード入力で+1か-1を返す
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを決める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動するメソッドMoveを呼び出す
        SpaceShip.Move(direction);
	}

    // 何かにぶつかった時に呼びだされるメソッド
    void OnTriggerEnter2D(Collider2D C)
    {
        // レイヤーの名前をLayerNameに取得する
        string LayerName = LayerMask.LayerToName(C.gameObject.layer);

        // レイヤー名がBullet(Enemy)の場合
        if ( LayerName == "Bullet(Enemy)")
        {
            // 弾を削除
            Destroy(C.gameObject);
        }

        // レイヤー名がBullet(Enemy),Enemyだった場合
        if ( LayerName == "Bullet (Enemy)" || LayerName == "Enemy")
        {
            // 機体が爆発する
            SpaceShip.Explosion();

            // Playerオブジェクトの削除
            Destroy(gameObject);
        }
    }
}
