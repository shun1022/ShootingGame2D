using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    // Playerプレハブ
    public GameObject Player;

    // Title
    public GameObject Title;

    public GameObject GameOverGUI;

    // Scoreコンポーネントの取得
    public Score Score;

    public int Stock = 2;

	// Use this for initialization
	void Start () {

        // Titleゲームオブジェクトを検索して取得する
        Title = GameObject.Find("Title");

        GameOverGUI.SetActive(false);
	}
	
	// Update is called once per frame
	void OnGUI () {

            // ゲーム中ではなくタッチもしくはマウスクリック直後であればtrueを返す
        if (IsPlaying() == false && Event.current.type == EventType.MouseDown)
            {
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
        Stock = Stock - 1;
        if (Stock == -1)
        {
            GameEnd();
        }else{
            Instantiate(Player, Player.transform.position, Player.transform.rotation);
        }

    }

    public void GameEnd()
    {
        GameOverGUI.SetActive(true);
                   
        // ハイスコアを保存する
        FindObjectOfType<Score>().Save();

        // タイトルを表示する
        Title.SetActive(true);

        // スコアの初期化
        Score.Intialaize(); 
    }

    // bool型の戻り値を返す関数の宣言
    public bool IsPlaying ()
    {

        // タイトルが表示されていればゲーム中ではない
        return Title.activeSelf == false;
    }
}
