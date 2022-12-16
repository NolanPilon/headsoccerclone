using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    private Vector2 p1Spawn = new Vector2(-7.0f,-2.5f);
    private Vector2 p2Spawn = new Vector2(7.0f, -2.5f);

    private void Start()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1) 
        {
            PhotonNetwork.Instantiate(playerPrefab.name, p1Spawn, Quaternion.identity);
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, p2Spawn, transform.rotation * Quaternion.Euler(0, 180, 0));
        }
    }
}
