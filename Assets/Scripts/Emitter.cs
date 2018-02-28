using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    // Waveプレハブを格納するメンバ変数
    public GameObject[] Waves;

    // 現在のWaveを参照する為のローカル変数
    private int CurrentWave;

    // 開始時にコルーチンでメソッドを呼びだす
    IEnumerator Start ()
    {
        
        // Waveが無ければ終了する
        if (Waves.Length == 0)
        {
            yield break;
        }

        // くりかえす
        while (true)
        {
            
            // Waveを作成する
            GameObject Wave = (GameObject)Instantiate(Waves[CurrentWave], transform.position, Quaternion.identity);

            // WaveをEmitterの子要素にする
            Wave.transform.parent = transform;

            // Waveの子要素Enemyが全て削除されるまで待機する
            while(Wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            // Waveの削除
            Destroy(Wave);

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
