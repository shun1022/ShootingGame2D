using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class SpaceShip : MonoBehaviour {

    public float Speed;
    public float ShotDelay;
    public GameObject Bullet;

    public void Shot (Transform origin)
    {
        Instantiate(Bullet, origin.position, origin.rotation);
    }

    public void Move (Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * Speed;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
