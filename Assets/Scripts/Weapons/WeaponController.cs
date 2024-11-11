using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for all weapon controllers
/// </summary>

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Statss")]
    public WeaponScriptableObject wpData;
    float currentCooldown;
    protected Playermovement pm;
    protected virtual void Start()
    {
        pm = FindObjectOfType<Playermovement>();
        currentCooldown = wpData.CooldownDuration; //At the start set the cooldown to be the cooldown duration
    }

    
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f) //Once the cooldown becomes 0, attack
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = wpData.CooldownDuration;
    }
}
