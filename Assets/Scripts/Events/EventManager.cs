using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action OnBallInBasket;

    public static Action OnGameEnded;

    public static Action OnGameRestart;

    public static void OnBallInBasketInvoke()
    {
        OnBallInBasket?.Invoke();
    }

    public static void OnGameEndedInvoke()
    {
        OnGameEnded?.Invoke();
    }

    public static void OnGameRestartInvoke()
    {
        OnGameRestart?.Invoke();
    }
}
