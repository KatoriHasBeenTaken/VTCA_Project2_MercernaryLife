using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }


    protected override void Attack()
    {
        
        base.Attack();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        GameObject spawnedBullet = Instantiate(wpData.prefab);
        spawnedBullet.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedBullet.GetComponent<GunBehaviour>().DirectionChecker(pm.lastMoveVector); //Refrence and set the diretion
    }
}
