using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // 
    SpaceShip SpaceShip;

    // 
    public GameObject Bullet;
        
    // 
    IEnumerator Start () {
        // 
        SpaceShip = GetComponent<SpaceShip>();
        // 
        while (true) {
            SpaceShip.Shot(transform);
            yield return new WaitForSeconds(SpaceShip.ShotDelay);
        }
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        SpaceShip.Move (direction);
	}
}
