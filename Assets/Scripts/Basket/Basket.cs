using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Basket : MonoBehaviour
{
    private bool _collided;

    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI popupText;
    public List<string> popupTexts = new List<string>();
    
    private void Start()
    {
        transform.DOScale(1, 0.25f).From(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ball ball;
        if (other.gameObject.TryGetComponent<Ball>(out ball))
        {
            ball = other.gameObject.GetComponent<Ball>();
            if (_collided)
            {
                GameController.Instance.canShoot = true;
                return;
            }
            else
            {
                BasketSpawner.Instance.lastBasket = this;
                EventManager.OnBallInBasketInvoke();
                ShowPopup();
                _collided = true;
            }
        }
    }

    private void ShowPopup()
    {
        popup.SetActive(true);
        popupText.text = $"{popupTexts[Random.Range(0, popupTexts.Count)]}";
    }
    
    public void DestroyThisBasket()
    {
        transform.DOScale(0, 0.5f).From(1).OnComplete(Destroy);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
