using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BasketSpawner : MonoBehaviour
{
    #region SingleTon

    public static BasketSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    
    [SerializeField] private GameObject basketPrefab;

    [SerializeField] private Vector3 newBasketPosition;
    [SerializeField] private float minOffsetX,maxOffsetX,minOffsetY, maxOffsetY;

    public Basket lastBasket;

    private float offsetX;
    public float offsetY { get; private set; }

    private void Start()
    {
        EventManager.OnBallInBasket += CreateNewBasket;
    }

    private void CreateNewBasket()
    {
        newBasketPosition = lastBasket.transform.position;

        offsetX = Random.Range(minOffsetX, maxOffsetX);
        offsetY = Random.Range(minOffsetY, maxOffsetY);

        Instantiate(basketPrefab,
            new Vector3(0 + offsetX, newBasketPosition.y + offsetY, 0),
            quaternion.identity);
    }
}