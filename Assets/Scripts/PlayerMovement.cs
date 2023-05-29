using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D collide;

    [SerializeField] private LayerMask jumpGround;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpForse = 7;
    private float dirX = 0f;
    private float AttackRate = 2f;
    private float nextAttackTime = 0f;
    public GameObject firePrefab;
    public Transform AttackPoint;
    public LayerMask Enemy;
    public static bool isMoving = true;

    private enum MovementStatus { stay, run, jump, fall }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForse);
        }

        UpdateAnimationChange();

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Attack();
                nextAttackTime = Time.time + 2f / AttackRate;
            }
        }

    }

    void Attack()
    {
        Instantiate(firePrefab, AttackPoint.position, AttackPoint.rotation);
    }

    private void UpdateAnimationChange()
    {

        MovementStatus status;

        if(isMoving)

        {
            if (dirX > 0f)
            {
                status = MovementStatus.run;
                transform.localScale = new Vector3(1f, 1f, 1f);
                AttackPoint.transform.localRotation = Quaternion.identity;
            }
            else if (dirX < 0f)
            {
                status = MovementStatus.run;
                transform.localScale = new Vector3(-1f, 1f, 1f);
                AttackPoint.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            }

            else
            {
                status = MovementStatus.stay;
            }

            if (rb.velocity.y > .1f)
            {
                status = MovementStatus.jump;
            }

            else if (rb.velocity.y < -.1f)
            {
                status = MovementStatus.fall;
            }

            anim.SetInteger("status", (int)status);
        }    

    }

    private bool IsGround()
    {
        return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
}
