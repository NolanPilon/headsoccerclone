using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InsideNet : MonoBehaviour
{       
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.UpdateScore();
            GameManager.Instance.StartCoroutine("SpawnNewBall");
            PhotonNetwork.Destroy(collision.gameObject);
        }
    }
}
