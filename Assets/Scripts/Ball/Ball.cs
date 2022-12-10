using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject myBall;

    public bool BallIsLive = false;

    void Start()
    {
        Instantiate(myBall, new Vector3(0, 0, 0), Quaternion.identity);
        BallIsLive = true;
    }

    public void SpawnNewBall()
    {
        Instantiate(myBall, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
