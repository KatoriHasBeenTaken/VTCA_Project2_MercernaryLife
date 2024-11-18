using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

    [Header("Health")]
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthBar;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    [Header("Interaction")]
    public float interactRange = 2f;
    public LayerMask npcLayer;

    [Header("Animation")]
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Initialize health
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        AnimatePlayer();

        if (Input.GetMouseButtonDown(0)) // Shoot
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.E)) // Interact with NPC
        {
            InteractWithNPC();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;

        if (horizontal != 0)
        {
            // Flip sprite based on movement direction
            transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void Move()
    {
        // Movement logic is already handled in HandleMovement for platformers
    }

    void AnimatePlayer()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("IsGrounded", isGrounded);
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("Bullet Prefab or Fire Point not assigned!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = firePoint.right * bulletSpeed * transform.localScale.x; // Fire direction depends on facing
        Destroy(bullet, 2f);
    }

    void InteractWithNPC()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange, npcLayer);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("NPC"))
            {
                Debug.Log("Interacted with " + hit.name);
                hit.GetComponent<NPC>().Interact();
                break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Add death animation or reload scene logic
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
