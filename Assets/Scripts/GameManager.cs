using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI timer;
    public TextMeshProUGUI[] scoreText;
    public  int[] score;
    private float matchTime;
    private float minutes;
    private float seconds;

    public GameObject myBall;
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
        score[0] = 0;
        score[1] = 0;
        matchTime = 120;
        StartCoroutine("SpawnNewBall");
    }

    private void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer() 
    {
        minutes = Mathf.FloorToInt(matchTime / 60);
        seconds = Mathf.FloorToInt(matchTime % 60);
        timer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        matchTime -= Time.deltaTime;
    }

    public void UpdateScore() 
    {
        if (gameBall.transform.position.x > 0)
        {
            score[0]+=1;
            scoreText[0].text = score[0].ToString();
        }
        else if (gameBall.transform.position.x < 0)
        {
            score[1]+=1;
            scoreText[1].text = score[1].ToString();
        }
    }

    public IEnumerator SpawnNewBall()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(myBall, new Vector3(0, 0, 0), Quaternion.identity);
        gameBall = GameObject.FindGameObjectWithTag("Ball");
    }
}
