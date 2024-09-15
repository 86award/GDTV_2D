using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    bool jumpInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    float baseGravityValue;

    [SerializeField] float runSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float climbSpeed;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        baseGravityValue = myRigidbody.gravityScale;
    }

    void Update()
    {
        Run();
        FlipSprite();
        Climb();
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
        if (GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Climbing")))
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
        if (value.isPressed && GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
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
