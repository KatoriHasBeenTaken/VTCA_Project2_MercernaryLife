using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : ProjecttileWeaponBehaviour
{



    protected override void Start()
    {
        base.Start();

    }

    
    void Update()
    {
        transform.position += direction * wpData.Speed * Time.deltaTime; //Set the movement of the knife
    }
}
