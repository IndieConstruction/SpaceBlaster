using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public TextMeshProUGUI Score;

    public Image Shield;

    PlayerData playerData;
    private void Awake() {
        playerData = GetComponent<PlayerData>();
    }

    void UpdateCanvasScore() {
        Score.text = playerData.Score.ToString();
    }

    private void Update() {
        UpdateCanvasScore();
    }

}
