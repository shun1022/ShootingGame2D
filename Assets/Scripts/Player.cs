using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5;

    public GameObject Bullet;
        
    IEnumerator Start () {
        while (true) {
            Instantiate(Bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.05f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}
