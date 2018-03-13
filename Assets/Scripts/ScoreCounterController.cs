using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterController : MonoBehaviour {

    public Text scoreText;
    public PlayerData currentPlayer;

    private void OnEnable() {
        EventManager.OnScoreUpdated += UpdateScore;
    }

    private void UpdateScore(PlayerData player) {
        if(player == currentPlayer)
            scoreText.text = player.Score.ToString();
    }

    private void OnDisable() {
        EventManager.OnScoreUpdated -= UpdateScore;
    }
}
