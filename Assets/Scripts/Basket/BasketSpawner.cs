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
    [SerializeField] private Vector3 restartBasketPosition;
    [SerializeField] private float minOffsetX,maxOffsetX,minOffsetY, maxOffsetY;

    public Basket lastBasket;

    public List<GameObject> basketsList = new List<GameObject>();

    private float offsetX;
    public float offsetY { get; private set; }

    private void Start()
    {
        EventManager.OnBallInBasket += CreateNewBasket;
        EventManager.OnGameEnded += DeleteAllBaskets;
        EventManager.OnGameRestart += CreateFirstBasket;
    }

    private void CreateNewBasket()
    {
        newBasketPosition = lastBasket.transform.position;

        offsetX = Random.Range(minOffsetX, maxOffsetX);
        offsetY = Random.Range(minOffsetY, maxOffsetY);

        var basket = Instantiate(basketPrefab,
            new Vector3(0 + offsetX, newBasketPosition.y + offsetY, 0),
            quaternion.identity);
        basketsList.Add(basket);
        
        DeleteBasket();
    }

    private void DeleteBasket()
    {
        if (basketsList.Count > 3)
        {
            basketsList[0].GetComponent<Basket>().DestroyThisBasket();
            basketsList.RemoveAt(0);
        }
    }

    private void DeleteAllBaskets()
    {
        for (int i = 0; i < basketsList.Count; i++)
        {
            Destroy(basketsList[i]);
        }
        basketsList.Clear();
    }

    private void CreateFirstBasket()
    {
        var basket = Instantiate(basketPrefab,
            new Vector3(restartBasketPosition.x, restartBasketPosition.y, restartBasketPosition.z),
            quaternion.identity);
        basketsList.Add(basket);
    }
}
