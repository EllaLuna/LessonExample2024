using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    ScoreChannel scoreChannel;

    void Start()
    {
        var beacon = FindObjectOfType<Beacon>();
        scoreChannel = beacon.scoreChannel;
        scoreChannel.UpdateScore += UpdateScore;
    }

    public void UpdateScore(int update, string targetName)
    {
        score += update;
        scoreText.text = $"Score: {score}";
    }

    private void OnDestroy()
    {
        scoreChannel.UpdateScore -= UpdateScore;
    }
}