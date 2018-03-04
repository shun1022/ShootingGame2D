﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    // Playerプレハブ
    public GameObject Player;

    // Title
    private GameObject Title;

    public Score Score;

	// Use this for initialization
	void Start () {

        // Titleゲームオブジェクトを検索して取得する
        Title = GameObject.Find("Title");
	}
	
	// Update is called once per frame
	void Update () {
        
		// ゲーム中ではなく、かつXキーが押されたらtrueを返す
        if (IsPlaying () == false && Input.GetKeyDown(KeyCode.X))
        {
            // GameStartメソッドを呼びだす
            GameStart();
        }
	}

    // メソッドの宣言
    void GameStart ()
    {
       // Titleオブジェクトを非表示にする
        Title.SetActive(false);

        // Playerオブジェクトを作成する
        Instantiate(Player, Player.transform.position, Player.transform.rotation);
    }

    // メソッドの宣言
    public void GameOver ()
    {

        // ハイスコアを保存する
        FindObjectOfType<Score>().Save();

        // タイトルを表示する
        Title.SetActive(true);

        Score.Intialaize();

    }

    // bool型の戻り値を返す関数の宣言
    public bool IsPlaying ()
    {

        // タイトルが表示されていればゲーム中ではない
        return Title.activeSelf == false;
    }
}
