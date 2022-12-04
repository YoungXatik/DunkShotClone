using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    [SerializeField] private Transform walls;
    [SerializeField] private float offsetY;

    private void Start()
    {
        EventManager.OnBallInBasket += UpdateWallsPosition;
    }

    private void UpdateWallsPosition()
    {
        walls.position = new Vector3(walls.position.x,walls.position.y + BasketSpawner.Instance.offsetY, 0);
        Debug.Log(BasketSpawner.Instance.offsetY);
    }
}
