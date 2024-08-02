using System;
using System.Runtime.InteropServices;
using Mono.Cecil.Cil;
using NUnit.Framework;
using UnityEditor.Callbacks;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SurfaceEffector2D ground;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float normalSpeed = 10f;
    [SerializeField] float boostSpeed = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        ground = FindFirstObjectByType<SurfaceEffector2D>();
    }


    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        BoostPlayer();

    }

    private void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift)) ground.speed = boostSpeed;
        else ground.speed = normalSpeed;
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-torqueAmount);
        }
    }
}
