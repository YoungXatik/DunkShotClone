using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;

    [SerializeField] private Transform playerObject;
    [SerializeField] private Vector2 playerStartPosition;

    [SerializeField] private Animator deathScreenAnimator;
    [SerializeField] private TextMeshProUGUI reachedScoresText;

    private LockCameraZ _mainCameraFollowComponent;

    private void Start()
    {
        deathScreen.SetActive(false);
        _mainCameraFollowComponent = Camera.main.gameObject.GetComponent<LockCameraZ>();
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
        deathScreen.SetActive(true);
        EventManager.OnGameEndedInvoke();
        _mainCameraFollowComponent.enabled = false;
        StartAnimation();
        reachedScoresText.text = $"YOU REACHED {PlayerPrefs.GetInt("Scores")} SCORES";
    }

    [ContextMenu("TestAnimation")]
    private void StartAnimation()
    {
        deathScreenAnimator.SetBool("idle",false);
        deathScreenAnimator.SetBool("open",true);
    }

    public void RestartGame()
    {
        EventManager.OnGameRestart();
        deathScreenAnimator.SetBool("open",false);
        deathScreenAnimator.SetBool("idle",true);
        playerObject.position = playerStartPosition;
        _mainCameraFollowComponent.enabled = true;
    }
}
