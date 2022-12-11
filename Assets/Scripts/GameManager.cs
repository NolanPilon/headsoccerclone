using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI timer;
    private float matchTime;
    private float minutes;
    private float seconds;

    public GameObject myBall;
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
        matchTime = 120;
        StartCoroutine("spawnNewBall");
    }

    private void Update()
    {
        updateTimer();
    }

    void updateTimer() 
    {
        minutes = Mathf.FloorToInt(matchTime / 60);
        seconds = Mathf.FloorToInt(matchTime % 60);
        timer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        matchTime -= Time.deltaTime;
    }
    public IEnumerator spawnNewBall()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(myBall, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
