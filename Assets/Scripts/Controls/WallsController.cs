using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    [SerializeField] private Transform walls;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private float offsetY;

    private void Start()
    {
        startPos = transform.position;
        EventManager.OnBallInBasket += UpdateWallsPosition;
        EventManager.OnGameRestart += SetPositionToDefault;
    }

    private void UpdateWallsPosition()
    {
        walls.position = new Vector3(walls.position.x,walls.position.y + BasketSpawner.Instance.offsetY, 0);
    }

    private void SetPositionToDefault()
    {
        walls.position = startPos;
    }
    
}
