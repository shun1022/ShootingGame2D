using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour {

    public Manager Manager;

    public GUIText StockGUIText;

	// Use this for initialization
	void Start () {
        StockGUIText.text = "Stock:" + Manager.Stock.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        StockGUIText.text = "Stock:" + Manager.Stock.ToString();
	}
}
