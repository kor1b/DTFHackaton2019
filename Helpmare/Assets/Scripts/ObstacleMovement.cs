using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
            UpdateMovement (collision.rigidbody.velocity);
            FreezeAxis();
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
            movement = Vector2.zero;
            FreezeAxis();
        }
    }

    private void UpdateMovement (Vector2 velocity)
    {
        if (Mathf.Abs (rb.velocity.x - rb.velocity.y) <= 0.2)
        {
            movement.x = 0;
            movement.y = 1;

            return;
        }

        if (Mathf.Abs (rb.velocity.x) - Mathf.Abs (rb.velocity.y) > 0.2)
        {
            movement.x = 1;
        }
        else
        {
            movement.x = 0;
        }

        if (Mathf.Abs (rb.velocity.y) - Mathf.Abs (rb.velocity.x) > 0.2)
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
        else if (movement.x == 0)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }
}