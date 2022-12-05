using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallSettings : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ballRenderer;
    [SerializeField] private TextMeshProUGUI menuText;
    [SerializeField] private float textDelay;

    [SerializeField] private Image menuImage;
    [SerializeField] private GameObject closeButton;

    public void SetNewSprite(Sprite sprite)
    {
        ballRenderer.sprite = sprite;
        StartCoroutine(ChangeText());
    }

    private IEnumerator ChangeText()
    {
        menuText.text = "SUCCESSFULLY!";
        yield return new WaitForSeconds(textDelay);
        menuText.text = "CHOOSE A BALL";
    }

    public void OpenMenu()
    {
        GameController.Instance.enabled = false;
        menuImage.gameObject.SetActive(true);
        closeButton.SetActive(true);
        menuImage.transform.DOScale(1, 0.3f).SetEase(Ease.Linear).From(0);
    }

    public void CloseMenu()
    {
        menuImage.transform.DOScale(0, 0.3f).SetEase(Ease.Linear).From(1);
        closeButton.SetActive(false);
    }
}
