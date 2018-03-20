using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    SpaceShip SpaceShip;

    public void MoveItem(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * SpaceShip.Speed;
    }

    // Use this for initialization
    public void Start()
    {
        SpaceShip = GetComponent<SpaceShip>();
        MoveItem(transform.up * -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}