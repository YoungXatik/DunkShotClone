using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private bool _collided;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Ball ball;
        if (other.gameObject.TryGetComponent<Ball>(out ball))
        {
            ball = other.gameObject.GetComponent<Ball>();
            if (_collided)
            {
                return;
            }
            else
            {
                BasketSpawner.Instance.lastBasket = this;
                EventManager.OnBallInBasketInvoke();
                _collided = true;
            }
        }
    }
}
