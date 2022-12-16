using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball : MonoBehaviour
{
    Rigidbody2D ballRB;
    PhotonView view;

    private int kickForce = 16;
    private bool inRange = false;
    private void Start()
    {
        view = GetComponent<PhotonView>();
        ballRB = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        //Check which player kicked and adjust ball velocity accordingly 
        if (inRange == true && PhotonNetwork.LocalPlayer.ActorNumber == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            view.RPC("kickedBall", RpcTarget.All, 1);
        }
        else if (inRange == true && PhotonNetwork.LocalPlayer.ActorNumber == 2 && Input.GetKeyDown(KeyCode.Space)) 
        {
            view.RPC("kickedBall", RpcTarget.All, -1);
        }
    }

    [PunRPC]
    void kickedBall(int dir)
    {
        ballRB.AddForce(new Vector2(kickForce * dir, kickForce / 2), ForceMode2D.Impulse);
    }

    //Check if in player range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kick"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kick"))
        {
            inRange = false;
        }
    }
}
