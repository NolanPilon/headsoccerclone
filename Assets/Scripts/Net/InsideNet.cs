using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideNet : MonoBehaviour
{       
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.UpdateScore();
            Destroy(collision.gameObject);
            GameManager.Instance.StartCoroutine("SpawnNewBall");
        }
    }
}
