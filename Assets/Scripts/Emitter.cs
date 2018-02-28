using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    // Waveプレハブを格納するメンバ変数
    public GameObject[] Waves;

    // 現在のWaveを参照する為のローカル変数
    private int CurrentWave;

    // Managerコンポーネント
    private Manager Manager;

    // 開始時にコルーチンでメソッドを呼びだす
    IEnumerator Start ()
    {
        
        // Waveが無ければ終了する
        if (Waves.Length == 0)
        {
            yield break;
        }

        // Managerコンポーネントを探して取得する
        Manager = FindObjectOfType<Manager>();

        // くりかえす
        while (true)
        {

            // Title表示中の処理
            while (Manager.IsPlaying() == false)
            {
                // 待機する
                yield return new WaitForEndOfFrame();
            }

            // Waveを作成する
            GameObject G = (GameObject)Instantiate(Waves[CurrentWave], transform.position, Quaternion.identity);

            // WaveをEmitterの子要素にする
            G.transform.parent = transform;

            // Waveの子要素Enemyが全て削除されるまで待機する
            while(G.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            // Waveの削除
            Destroy (G);

            // 格納されているWaveを全て実行したらCurrentWaveに0を代入する
            if (Waves.Length <= ++CurrentWave)
            {
                CurrentWave = 0;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
