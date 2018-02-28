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

            // GetComponentでAudioSourceを取得しPlayメソッドで再生する
            GetComponent<AudioSource>().Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        // GetAxisRawメソッドによりキーボード入力で+1か-1を返す
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを決める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動範囲を制限する
        Move(direction);
	}

    // メソッドMoveの宣言
    void Move(Vector2 direction)
    {

        // 画面左下のワールド座標をローカル変数minにビューポートから取得する
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をローカル変数maxにビューポートから取得する
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤー位置をローカル変数posに取得する
        Vector2 pos = transform.position;

        // 運動量を加える
        pos += direction * SpaceShip.Speed * Time.deltaTime;

        // プレイヤー位置を画面内に収まる値に制限する
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限内の位置にプレイヤーを移動する
        transform.position = pos;

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

            // Managerコンポーネントを探して取得し、GameOverメソッドを呼び出す
            FindObjectOfType<Manager>().GameOver();
        }
    }
}
