using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI[] scoreText;
    public  static int leftScore;
    public static int rightScore;
    private float matchTime;
    private float minutes;
    private float seconds;
    public bool ballInPlay;

    private GameObject gameBall;
    public float ballTimer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        leftScore = 0;
        rightScore = 0;
        matchTime = 120;
    }

    private void Update()
    {
        //Once 2 players join the timer starts and ball spawns
        if (ballInPlay == false && PhotonNetwork.CurrentRoom.PlayerCount == 2) 
        {
            StartCoroutine("SpawnNewBall");
            ballInPlay = true;
        }

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            UpdateTimer();

        //End Game
        if (matchTime <= 0) 
        {
            PhotonNetwork.LoadLevel("Loading");
        }

        UpdateScoreText();
    }

    void UpdateTimer() 
    {
        minutes = Mathf.FloorToInt(matchTime / 60);
        seconds = Mathf.FloorToInt(matchTime % 60);
        timer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        matchTime -= Time.deltaTime;
    }
    public void UpdateScoreText()
    {
        scoreText[0].text = leftScore.ToString();
        scoreText[1].text = rightScore.ToString();
    }

    public IEnumerator SpawnNewBall()
    {
        yield return new WaitForSeconds(2.0f);
        PhotonNetwork.InstantiateRoomObject("Ball", new Vector3(0, 1, 0), Quaternion.identity);
        gameBall = GameObject.FindGameObjectWithTag("Ball");
    }
}
