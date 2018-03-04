using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // SpaceShipコンポーネントを追加
    SpaceShip SpaceShip;

    // メンバ変数
    public int HP = 1;

    // 
    public int point = 10000;

    // コルーチンでメソッドStartを呼びだす
    IEnumerator Start()
    {
        // GetComponentでSpaceShipクラスのインスタンスを取得しローカル変数SpaceShipで保持
        SpaceShip = GetComponent<SpaceShip>();

        // Moveメソッドを呼びだしy方向に移動する
        Move(transform.up * -1);

        // CanShotにチェックが入っていなければそれを中断する
        if (SpaceShip.CanShot == false){
            yield break;
        }
            
        // 以下を繰り返す
        while (true) {
            
            // int型の変数iを宣言し0を代入、子要素ShotPositionを全て取得するまで繰り返す
            for (int i = 0; i < transform.childCount; i++){
                
                // GetChildメソッドでi番目かつTransformクラスの子要素ShotPositionを取得
                Transform ShotPosition = transform.GetChild(i);

                // Shotメソッドを呼び出し、ShotPositionの位置と角度で弾を撃つ
                SpaceShip.Shot(ShotPosition);
            }

            // ShotDelay杪待つ
            yield return new WaitForSeconds(SpaceShip.ShotDelay);
            }
    }

    // 
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * SpaceShip.Speed;
    }
    // 何かにぶつかると呼び出されるメソッド
    void OnTriggerEnter2D(Collider2D C)
    {
        // ローカル変数LayerNameにレイヤー名を取得
        string LayerName = LayerMask.LayerToName(C.gameObject.layer);

        // レイヤー名がBullet (Player)である時以外何もしない
        if (LayerName != "Bullet (Player)") return;

        // PlayerBulletのTransformを取得
        Transform PlayerBulletTransform = C.transform.parent;

        // Bulletコンポーネントを取得
        Bullet Bullet = PlayerBulletTransform.GetComponent<Bullet>();

        // HPを減らす
        HP = HP - Bullet.Power;

        // 弾を削除
        Destroy(C.gameObject);

        // HPが0ならば
        if (HP <= 0)
        {

            // スコアコンポーネントを探して取得、ポイントを追加
            FindObjectOfType<Score>().AddPoint(point);

            // 爆発
            SpaceShip.Explosion();

            // Enemyの削除
            Destroy(gameObject);

            // そうで無ければ
        }else{

            // Damageトリガーをセットする
            SpaceShip.GetAnimator().SetTrigger("Damage");
        }
    }
}
