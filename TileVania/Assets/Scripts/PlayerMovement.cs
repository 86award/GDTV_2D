using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 move;
    Rigidbody2D rb;

    [SerializeField] float runSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        rb.linearVelocityX = move.x * runSpeed;
    }

    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    
}
