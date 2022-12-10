using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 12f;
    private float horizontalMovement;
    private float verticalMovement;
    private Rigidbody2D rB;


    [Header("Jumping")]
    public float jumpForce = 20f;
    public bool onGround = false;

    private void Start() => rB = GetComponent<Rigidbody2D>();

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        verticalMovement = Input.GetAxisRaw("Vertical");

        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if(verticalMovement < 0)
        {
            rB.velocity = new Vector2(rB.velocity.x, rB.velocity.y + verticalMovement);
        }    

        rB.velocity = new Vector2(horizontalMovement * movementSpeed, rB.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
