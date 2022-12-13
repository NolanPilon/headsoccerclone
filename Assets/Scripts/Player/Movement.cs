using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private float horizontalMovement;
    private float verticalMovement;
    private Rigidbody2D rB;
    public float jumpForce = 20f;
    public bool onGround = false;

    PhotonView view;

    private void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    } 

    private void Update()
    {
        if(view.IsMine)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");

            verticalMovement = Input.GetAxisRaw("Vertical");

            if (onGround && Input.GetKeyDown(KeyCode.W))
            {
                rB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            if (verticalMovement < 0)
            {
                rB.velocity = new Vector2(rB.velocity.x, rB.velocity.y + verticalMovement);
            }

            rB.velocity = new Vector2(horizontalMovement * movementSpeed, rB.velocity.y);
        }
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
