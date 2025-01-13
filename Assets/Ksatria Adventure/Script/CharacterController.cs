using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    private Vector3 initialScale;
    private Animator animator;
    private Rigidbody2D rb;

    [Header("Movement Settings")]
    public float speed = 1f;
    public float jumpForce = 10f;
    public float attackSpeed = 10f;

    private bool isGrounded = true;

    void Start()
    {
           
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Handle Movement
        float move = Input.GetAxis("Horizontal");
        HandleMovement(move);

        // Handle Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            HandleJump();
        }

        // Handle Attack
        if (Input.GetButtonDown("Fire1")) // Fire1 default is left mouse or ctrl
        {
            HandleAttack();
        }
    }

    private void HandleMovement(float move)
    {
        if (move != 0)
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(move * speed * Time.deltaTime, 0, 0));
            // transform.localScale = new Vector3(
            //     Mathf.Sign(move) * Mathf.Abs(initialScale.x), 
            //     initialScale.y, 
            //     initialScale.z
            // );

            // if (move > 0)
            // {
            //     transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
            // }
            // else if (move < 0)
            // {
            //     transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
            // }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void HandleJump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        animator.SetBool("isJumping", true);
        isGrounded = false;
    }

    private void HandleAttack()
    {
        animator.SetBool("isAttacking", true);

        // Delay to reset the attack animation state
        Invoke(nameof(ResetAttack), 0.5f);
    }

    private void ResetAttack()
    {
        animator.SetBool("isAttacking", false);
    }

    // Detect when character lands on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }
}