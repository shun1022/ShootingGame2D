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
            
        // 以下を繰返す
        while (true) {
            // int型の変数iを宣言し0を代入、
            for (int i = 0; i < transform.childCount; i++){
                Transform ShotPosition = transform.GetChild(i);
                SpaceShip.Shot(ShotPosition);
            }

            yield return new WaitForSeconds(SpaceShip.ShotDelay);

        }
    }

}
