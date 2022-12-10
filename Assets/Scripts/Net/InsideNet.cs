using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideNet : MonoBehaviour
{
    public Ball NewBall;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            Invoke("SpawnTheDamnBall", 2);
        }
    }
    private void SpawnTheDamnBall()
    {
        NewBall.SpawnNewBall();
    }
}
