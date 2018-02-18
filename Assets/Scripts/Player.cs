﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    SpaceShip spaceship;

    public GameObject Bullet;
        
    IEnumerator Start () {
        spaceship = GetComponent<SpaceShip>();

        while (true) {
            spaceship.Shot(transform);
            yield return new WaitForSeconds(spaceship.ShotDelay);
        }
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        spaceship.Move (direction);
	}
}
