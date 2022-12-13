using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector2 newVec = new Vector2(-7.0f,-2.5f);

    private void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, newVec, Quaternion.identity);
    }
}
