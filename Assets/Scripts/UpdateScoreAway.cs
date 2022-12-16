using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScoreAway : MonoBehaviour
{
    private TextMeshProUGUI score;
    private void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        score.text = GameManager.Instance.score[1].ToString();
    }
}
