using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    // Playerプレハブ
    public GameObject Player;

    // Title
    public GameObject Title;

    // Scoreコンポーネントの取得
    public Score Score;

	// Use this for initialization
	void Start () {

        // Titleゲームオブジェクトを検索して取得する
        Title = GameObject.Find("Title");
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < Input.touchCount; i ++)
        {

            // タッチ情報を取得する
            Touch touch = Input.GetTouch(i);

            // ゲーム中ではなくタッチ直後であればtrueを返す
            if (IsPlaying() == false && touch.phase == TouchPhase.Began)
            {
                GameStart();
            }
        }

		// ゲーム中ではなく、かつマウスクリックされたらtrueを返す
        if (IsPlaying () == false && Input.GetMouseButtonDown(0))
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
