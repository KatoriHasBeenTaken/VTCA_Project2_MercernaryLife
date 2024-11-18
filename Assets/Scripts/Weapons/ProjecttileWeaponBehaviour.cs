using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script of all projectile behviour [To be placed on a prefab of a weapon that is a projectile]
/// </summary>
public class ProjecttileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject wpData;
    public Vector3 direction;
    public float destroyAfterSeconds;
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPiece;
    private void Awake()
    {
        currentDamage = wpData.Damage;
        currentSpeed = wpData.Speed;
        currentCooldownDuration = wpData.CooldownDuration;
        currentPiece = wpData.Pierce;
    }
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
        float dirx = direction.x;
        float diry = direction.y;
        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;
        if (dirx < 0 && diry == 0)      //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (diry == 0 && dirx < 0) //down
        {
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry > 0) //up
        {
            scale.x = scale.x * -1;
        }
        else if (dir.x > 0 && dir.y > 0) //right up
        {
            rotation.z = 0f;
        }
        else if (dir.x > 0 && dir.y < 0) //right down
        {
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y > 0) //left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y < 0) //left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }
        transform.localScale = scale;  
        transform.rotation = Quaternion.Euler(rotation);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
            ReducePiece();
        }
    }

    void ReducePiece()
    {
        currentPiece--;
        if(currentPiece <= 0)
        {
            Destroy(gameObject);
        }
    }
}
