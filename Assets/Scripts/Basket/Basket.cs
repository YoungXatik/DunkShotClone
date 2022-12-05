using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Basket : MonoBehaviour
{
    public bool _collided;

    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private float popupDelay;
    public List<string> popupTexts = new List<string>();

    [SerializeField] private ParticleSystem hitParticle;

    private void Start()
    {
        transform.DOScale(1, 0.25f).From(0);
        EventManager.OnColorChanged += ChangePopupTextColor;
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
                hitParticle.Play();
                EventManager.OnBallInBasketInvoke();
                StartCoroutine(ShowAndHidePopup());
                _collided = true;
            }
        }
    }

    private void ChangePopupTextColor()
    {
        popupText.DOColor(
            new Color(ColorController.Instance.currentTextColor.r, ColorController.Instance.currentTextColor.g,
                ColorController.Instance.currentTextColor.b, popupText.color.a), 0.3f);
    }
    
    private IEnumerator ShowAndHidePopup()
    {
        popupText.transform.DOScale(1, 0.5f).SetEase(Ease.Linear).From(0);
        popupText.text = $"{popupTexts[Random.Range(0, popupTexts.Count)]}";
        yield return new WaitForSeconds(popupDelay);
        HidePopup();
    }
    
    public void DestroyThisBasket()
    {
        transform.DOScale(0, 0.5f).From(1).OnComplete(Destroy);
    }

    public void HidePopup()
    {
        popupText.transform.DOScale(0, 0.25f).SetEase(Ease.Linear).From(1);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
