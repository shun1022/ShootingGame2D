using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // SpaceShipコンポーネントを追加
    SpaceShip SpaceShip;

    // コルーチンでメソッドStartを呼びだす
    IEnumerator Start()
    {
        // GetComponentでSpaceShipクラスのインスタンスを取得しローカル変数SpaceShipで保持
        SpaceShip = GetComponent<SpaceShip>();

        // Moveメソッドを呼びだしy方向に移動する
        SpaceShip.Move(transform.up * -1);

        // CanShotにチェックが入っていなければそれを中断する
        if (SpaceShip.CanShot == false){
            yield break;
        }
            
        // 以下を繰り返す
        while (true) {
            
            // int型の変数iを宣言し0を代入、子要素ShotPositionを全て取得するまで繰り返す
            for (int i = 0; i < transform.childCount; i++){
                
                // GetChildメソッドでi番目かつTransformクラスの子要素ShotPosition
                Transform ShotPosition = transform.GetChild(i);

                // Shotメソッドを呼び出し、ShotPositionの位置と角度で弾を撃つ
                SpaceShip.Shot(ShotPosition);
            }

            // ShotDelay杪待つ
            yield return new WaitForSeconds(SpaceShip.ShotDelay);

        }
    }

}
