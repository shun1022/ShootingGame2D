using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    // Waveプレハブを格納するメンバ変数
    public GameObject[] Waves;

    // 現在のWaveを参照する為のローカル変数
    private int CurrentWave;

    IEnumerator Start ()
    {
        // 
        if (Waves.Length == 0)
        {
            yield break;
        }

        // 
        while (true)
        {
            // 
            GameObject Wave = (GameObject)Instantiate(Waves[CurrentWave], transform.position, Quaternion.identity);


        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
