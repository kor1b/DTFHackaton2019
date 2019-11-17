using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;

    private float distanceToVerticalSide;
    private float distanceToHorizontalSide;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        distanceToVerticalSide = boxCollider.size.x / 2;
        distanceToHorizontalSide = boxCollider.size.y / 2;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        UpdateMovement(collision.rigidbody.velocity);
        FreezeAxis();
    }
    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        UpdateMovement(collision.rigidbody.velocity);
        FreezeAxis();
    }
    */
    private void OnCollisionExit2D(Collision2D collision)
    {
        movement = Vector2.zero;
        FreezeAxis();
    }

    private void UpdateMovement(Vector2 velocity)
    {
        if (Mathf.Abs(rb.velocity.x - rb.velocity.y) <= 0.2)
        {
            movement.x = 0;
            movement.y = 1;
            return;
        }

        if (Mathf.Abs(rb.velocity.x) - Mathf.Abs(rb.velocity.y) > 0.2) 
        {
            movement.x = 1;
        }
        else
        {
            movement.x = 0;
        }

        if (Mathf.Abs(rb.velocity.y) - Mathf.Abs(rb.velocity.x) > 0.2) 
        {
            movement.y = 1;
        }
        else
        {
            movement.y = 0;
        }
    }

    public void FreezeAxis()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (movement.x == 0 && movement.y == 0) //если не двигаемся
            return;
        if (movement.y == 0)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        else if(movement.x == 0)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }
}
