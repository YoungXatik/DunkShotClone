using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scores : MonoBehaviour
{
    [SerializeField] private int scoresCount = 0;
    [SerializeField] private TextMeshProUGUI scoresText;

    private void Start()
    {
        EventManager.OnBallInBasket += UpdateScoresCount;
        EventManager.OnGameEnded += HideScores;
        EventManager.OnGameRestart += ShowScores;
    }

    private void UpdateScoresCount()
    {
        scoresCount += 1;
        PlayerPrefs.SetInt("Scores", scoresCount);
        scoresText.text = scoresCount.ToString();
    }

    private void ShowScores()
    {
        scoresText.gameObject.SetActive(true);
        scoresCount = 0;
        PlayerPrefs.SetInt("Scores", scoresCount);
        scoresText.text = scoresCount.ToString();
    }

    private void HideScores()
    {
        scoresText.gameObject.SetActive(false);
    }
}

