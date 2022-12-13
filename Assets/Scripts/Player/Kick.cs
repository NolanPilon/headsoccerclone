 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Kick : MonoBehaviour
{
    Rigidbody2D ballRb;

    [SerializeField]
    private bool inRange;

    private bool canKick = true;
    private float kickTime = 0.8f;
    private int kickForce = 16;
    PhotonView view;
    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    private void Update()
    {
        if(view.IsMine)
        {
            KickBall();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            inRange = true;
            ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            inRange = false;
        }
    }

    //Change with player direction
    void KickBall() 
    {
        if (inRange && Input.GetKey(KeyCode.Space) && canKick)
        {
            ballRb.AddForce(new Vector2(kickForce, kickForce / 2), ForceMode2D.Impulse);
            canKick = false;
            StartCoroutine("KickTimer");
        }
    }
    IEnumerator KickTimer() 
    {
        yield return new WaitForSeconds(kickTime);
        canKick = true;
    }
}
