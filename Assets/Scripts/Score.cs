using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    // スコアを表示するテキスト
    public GUIText ScoreGUIText;

    // ハイスコアを表示するテキスト
    public GUIText HighScoreGUIText;

    // スコアを保持するローカル変数
    private int score;

    // ハイスコアを保持するローカル変数
    private int highScore;

    // PlayerPrefsで保存する為のキー
    private string highScoreKey = "highScore";


	// Use this for initialization
	void Start () {
        Intialaize();
	}
	
	// Update is called once per frame
	void Update () {
        // scoreがhighScoreより大きければハイスコアを更新する
        if (score > highScore)
        {
            highScore = score;
        }

        // string型に変換してGUITextに代入
        ScoreGUIText.text = score.ToString();
        HighScoreGUIText.text = "HIGH SCORE: " + highScore.ToString();

	}

    // ゲーム開始前の状態に戻すメソッド宣言
    private void Intialaize() 
    {
        // スコアを0に戻す
        score = 0;

        // highScoreを取得する。無ければ0を取得する
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // ポイントの追加をするメソッド宣言
    public void AddPoint (int point)
    {
        score = score + point;
    }

    // ハイスコアを保存するメソッド宣言
    public void Save ()
    {
        // ハイスコアを保存する
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();

        // ゲーム開始前の状態に戻すメソッドを呼び出す
        Intialaize();
    }
}
