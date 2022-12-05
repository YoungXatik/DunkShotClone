using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour
{
    #region Singleton

    public static ColorController Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    

    public Color currentTextColor;
    public Color currentImagesColor;
    
    public List<Color> imagesColors = new List<Color>();
    public List<Color> textColors = new List<Color>();
    
    public List<Image> inGameImages = new List<Image>();
    public List<TextMeshProUGUI> inGameTexts = new List<TextMeshProUGUI>();

    [SerializeField] private SpriteRenderer background;
    public List<Sprite> backgrounds = new List<Sprite>();
    
    public void ChangeImagesColor(int colorIndex)
    {
        currentImagesColor = imagesColors[colorIndex];
        for (int i = 0; i < inGameImages.Count; i++)
        {
            inGameImages[i].DOColor(new Color(currentImagesColor.r,currentImagesColor.g,currentImagesColor.b,inGameImages[i].color.a), 0.5f);
        }

        background.sprite = backgrounds[colorIndex];
    }

    public void ChangeTextColor(int colorIndex)
    {
        currentTextColor = textColors[colorIndex];
        for (int i = 0; i < inGameTexts.Count; i++)
        {
            inGameTexts[i].DOColor(new Color(currentTextColor.r,currentTextColor.g,currentTextColor.b,inGameTexts[i].color.a), 0.5f);
        }

        EventManager.OnColorChangedInvoke();
    }

    [SerializeField] private Image menuImage;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private GameObject blackButton;
    [SerializeField] private GameObject whiteButton;
    [SerializeField] private GameObject menuText;

    public void OpenMenu()
    {
        menuImage.transform.DOScale(1, 0.3f).SetEase(Ease.Linear).From(0);
        closeButton.SetActive(true);
        blackButton.SetActive(true);
        whiteButton.SetActive(true);
        menuText.SetActive(true);
    }

    public void CloseMenu()
    {
        menuImage.transform.DOScale(0, 0.3f).SetEase(Ease.Linear).From(1);
        closeButton.SetActive(false);
        blackButton.SetActive(false);
        whiteButton.SetActive(false);
        menuText.SetActive(false);
    }

}
