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

    [SerializeField] float runSpeed = 5;
    [SerializeField] float jumpForce = 5;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }
    
    private void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.linearVelocity.y);
        myRigidbody.linearVelocity = playerVelocity;

        bool playerHasVelocity = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasVelocity);
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
        if (value.isPressed)
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
