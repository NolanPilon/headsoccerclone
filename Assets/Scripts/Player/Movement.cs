using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

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
            movement();
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

    private void movement() 
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (onGround && Input.GetKeyDown(KeyCode.W))
        {
            rB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        transform.Translate(new Vector2(horizontalMovement * movementSpeed * Time.deltaTime, 0));
    }
}
