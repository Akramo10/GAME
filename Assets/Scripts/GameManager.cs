﻿using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour 
{
    private int score;
    public static GameManager inst;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private PlayerMovement playerMovement;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        score = 0;
        UpdateScoreDisplay();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreDisplay();
        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"SCORE: {score}";
        }
        else
        {
            Debug.LogWarning("Score Text reference is missing!");
        }
    }
}