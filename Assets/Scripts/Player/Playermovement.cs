using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    //movement
    private float horizontal;
    public float vanToc = 5.0f;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool isFacingRight = true;
    [SerializeField]
    private GameObject BulletPrefab;
    private NpcInteraction ;
    public float lucNhay = 5f;
    [SerializeField] private Rigidbody2D rb2D;
    private bool isGround = false;

    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMoveVector;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMoveVector = new Vector2(1, 0f);
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
            if (dialogueManager.dialogueBox.activeSelf)
            {
                dialogueManager.DisplayNextSentence(); // Advance dialogue
            }
            else
            {
                GiveQuest();
            }
        
        }

    void InputManagement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal > 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool("IsWalking", true);
            isFacingRight = true;
        }
        else if (horizontal < 0)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool("IsWalking", true);
            isFacingRight = false;
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb2D.AddForce(Vector2.up * lucNhay, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //vi tri tao vien dan
            Vector2 spwamPosition = transform.position;
            //van toc vien dan
            float bulletSpeed = 50f;
            if (isFacingRight)
            {
                spwamPosition += new Vector2(1, 0);
                bulletSpeed = 50;
            }
            else
            {
                spwamPosition += new Vector2(-1, 0);
                bulletSpeed = -50;
            }

            GameObject Bullet = Instantiate(BulletPrefab,
                                spwamPosition, Quaternion.identity);
            //lay component bomb
            Bullet bulletComponent = Bullet.GetComponent<Bullet>();

            bulletComponent.setSpeed(bulletSpeed);
        }


    }
}
