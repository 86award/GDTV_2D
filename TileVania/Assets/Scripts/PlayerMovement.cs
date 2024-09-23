using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    bool jumpInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    float baseGravityValue;
    bool isAlive;

    [SerializeField] float runSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float climbSpeed;
    [SerializeField] float deathKnock;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        baseGravityValue = myRigidbody.gravityScale;
        isAlive = true;
    }

    void Update()
    {
        if (isAlive)
        {
            Run();
            FlipSprite();
            Climb(); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;
        myAnimator.SetTrigger("Dead");
        myRigidbody.linearVelocityY = deathKnock;
    }

    private void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.linearVelocityY);
        myRigidbody.linearVelocity = playerVelocity;

        bool playerHasVelocity = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasVelocity);
    }

    private void Climb()
    {
        if (GetComponent<CapsuleCollider2D>().IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = 0f;
            Vector2 climbVelocity = new Vector2(myRigidbody.linearVelocityX, moveInput.y * climbSpeed);
            myRigidbody.linearVelocity = climbVelocity;

            bool playerHasVelocity = Mathf.Abs(myRigidbody.linearVelocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("isClimbing", playerHasVelocity);
        }
        else
        {
            myRigidbody.gravityScale = baseGravityValue;
            myAnimator.SetBool("isClimbing", false);
        }
    }

    private void FlipSprite()
    {
        bool playerHasVelocity = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        if (playerHasVelocity) transform.localScale = new Vector2 (MathF.Sign(myRigidbody.linearVelocity.x), 1f);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (isAlive)
        {
            // this prevents wall jump and jumping off of ladders/climbables 
            if (GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                if (value.isPressed && GetComponent<CapsuleCollider2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
                {
                    Debug.Log(myRigidbody.linearVelocity.x);
                    //myRigidbody.linearVelocity += new Vector2(0f, jumpForce); // this works
                    //myRigidbody.AddForce(new Vector2(0f, jumpForce)); // this works but requires much greater force i.e. 500
                    myRigidbody.linearVelocityY = jumpForce; // even at 500 this doesn't work
                                                             // It's because I was using x and not y 🙄
                    Debug.Log($"After pressing jump, .x is " + myRigidbody.linearVelocity.x);
                    Debug.Log($"After pressing jump, the vector is " + myRigidbody.linearVelocity);
                }
            } 
        }
    }
}
