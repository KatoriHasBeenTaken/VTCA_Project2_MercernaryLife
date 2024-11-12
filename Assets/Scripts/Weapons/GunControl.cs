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

        // Calculate the direction the player is facing
        Vector3 facingDirection = transform.right; // Assuming 'right' is the facing direction of the player
        facingDirection.z = 0f;

        // Instantiate bullet
        GameObject spawnedBullet = Instantiate(wpData.prefab);
        spawnedBullet.transform.position = transform.position; // Set bullet spawn position to player's position

        // Set bullet direction based on player's facing direction
        spawnedBullet.GetComponent<GunBehaviour>().DirectionChecker(facingDirection.normalized);
    }
}
