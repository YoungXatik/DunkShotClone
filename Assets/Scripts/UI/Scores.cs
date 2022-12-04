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
        UpdateScoresCount();
        EventManager.OnBallInBasket += UpdateScoresCount;
    }

    private void UpdateScoresCount()
    {
        scoresCount += 1;
        scoresText.text = scoresCount.ToString();
    }
}

