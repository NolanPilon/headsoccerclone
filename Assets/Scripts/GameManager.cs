using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI timer;
    private float time;
    private float minutes;
    private float seconds;

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
        time = 120;
    }

    private void Update()
    {
        updateTimer();
    }

    void updateTimer() 
    {
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        timer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        time -= Time.deltaTime;
    }
}
