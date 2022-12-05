using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    [SerializeField] private Transform playerObject;
    [SerializeField] private Vector2 playerStartPosition;

    [SerializeField] private GameObject deathScreen;
    [SerializeField] private TextMeshProUGUI reachedScoresText;
    [SerializeField] private TextMeshProUGUI defeatText;
    [SerializeField] private GameObject restartButton;

    private LockCameraZ _mainCameraFollowComponent;

    private AudioSource _source;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        deathScreen.SetActive(false);
        _mainCameraFollowComponent = Camera.main.gameObject.GetComponent<LockCameraZ>();
        _source = FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ball ball;
        if (other.TryGetComponent<Ball>(out ball))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _source.PlayOneShot(clip);
        deathScreen.SetActive(true);
        StartAnimation();
        EventManager.OnGameEndedInvoke();
        reachedScoresText.text = $"YOU REACHED {PlayerPrefs.GetInt("Scores")} SCORES";
    }

    [ContextMenu("TestAnimation")]
    private void StartAnimation()
    {
        restartButton.SetActive(true);
        deathScreen.transform.DOScale(1, 0.3f).SetEase(Ease.Linear).From(0);
        reachedScoresText
            .DOColor(new Color(reachedScoresText.color.r, reachedScoresText.color.g, reachedScoresText.color.b, 1),
                0.3f).SetEase(Ease.Linear);
        defeatText.DOColor(new Color(defeatText.color.r, defeatText.color.g, defeatText.color.b, 1), 0.3f)
            .SetEase(Ease.Linear);
        _mainCameraFollowComponent.ball = null;
    }

    public void RestartGame()
    {
        EventManager.OnGameRestartInvoke();
        EndAnimation();
        playerObject.position = playerStartPosition;
        _mainCameraFollowComponent.ball = playerObject;
    }

    private void EndAnimation()
    {
        restartButton.SetActive(false);
        deathScreen.transform.DOScale(0, 0.3f).SetEase(Ease.Linear).From(1);
        reachedScoresText
            .DOColor(new Color(reachedScoresText.color.r, reachedScoresText.color.g, reachedScoresText.color.b, 0),
                0.3f).SetEase(Ease.Linear);
        defeatText.DOColor(new Color(defeatText.color.r, defeatText.color.g, defeatText.color.b, 0), 0.3f)
            .SetEase(Ease.Linear);
    }
}
