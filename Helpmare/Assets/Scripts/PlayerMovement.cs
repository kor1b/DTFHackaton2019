﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField]
    private float moveSpeed = 1f;

    private Rigidbody2D rb;
    //private Animator animator;

    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        SetMovementAnimation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionExit2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Barricade"))
            AIMapRescanner.Rescan();
    }

    private void SetMovementAnimation()
    {
        //........TO DO.........

        //следующий кусок кода тупо взят из SaveTheOne
        /*if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            animator.ResetTrigger("RunRight");
            animator.ResetTrigger("Stay");
            animator.SetTrigger("RunLeft");
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.ResetTrigger("Stay");
            animator.ResetTrigger("RunLeft");
            animator.SetTrigger("RunRight");
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.ResetTrigger("RunRight");
            animator.ResetTrigger("RunLeft");
            animator.SetTrigger("Stay");
        }*/
    }
}
