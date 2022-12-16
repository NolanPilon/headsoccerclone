using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InsideNetLeft : MonoBehaviour
{
    PhotonView netView;

    private void Start()
    {
        netView = GetComponent<PhotonView>();   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            netView.RPC("PlayerScored", RpcTarget.All);
            GameManager.Instance.StartCoroutine("SpawnNewBall");
            PhotonNetwork.Destroy(collision.gameObject);
        }
    }

    [PunRPC]
    void PlayerScored()
    {
        GameManager.leftScore++;
    }
}
