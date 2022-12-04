using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;

    [SerializeField] private Transform playerObject;
    [SerializeField] private Vector2 playerStartPosition;
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
        EventManager.OnGameEndedInvoke();
        
        _mainCameraFollowComponent.enabled = false;
        //playerObject.position = playerStartPosition;
        deathScreen.SetActive(true);
    }
}
