using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action OnBallInBasket;

    public static void OnBallInBasketInvoke()
    {
        OnBallInBasket?.Invoke();
    }
}