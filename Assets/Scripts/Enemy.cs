using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    SpaceShip spaceship;

    IEnumerator Start()
    {
        spaceship = GetComponent<SpaceShip>();
        spaceship.Move(transform.up * -1);

        if (spaceship.CanShot == false){
            yield break;
        }
            

        while (true) {
            
            for (int i = 0; i < transform.childCount; i++){
                Transform ShotPosition = transform.GetChild(i);
                spaceship.Shot(ShotPosition);
            }

            yield return new WaitForSeconds(spaceship.ShotDelay);

        }
    }

}
