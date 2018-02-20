using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    SpaceShip SpaceShip;

    IEnumerator Start()
    {
        SpaceShip = GetComponent<SpaceShip>();
        SpaceShip.Move(transform.up * -1);

        if (SpaceShip.CanShot == false){
            yield break;
        }
            

        while (true) {
            
            for (int i = 0; i < transform.childCount; i++){
                Transform ShotPosition = transform.GetChild(i);
                SpaceShip.Shot(ShotPosition);
            }

            yield return new WaitForSeconds(SpaceShip.ShotDelay);

        }
    }

}
