using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tapToPlayText;
    [SerializeField] private Image pausePanel;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject ballSettingsButton;
    [SerializeField] private GameObject settingsButton;

    public ColorController colorController;

    private void Start()
    {
        EventManager.OnColorChanged += ChangeTextColor;
        GameController.Instance.enabled = false;
    }

    public void TapPlay()
    {
        GameController.Instance.enabled = true;
        GameController.Instance.trajectory.HideTrajectory();
        pausePanel.DOColor(new Color(colorController.currentImagesColor.r,colorController.currentImagesColor.g,colorController.currentImagesColor.b,0), 0.3f).SetEase(Ease.Linear);
        playButton.SetActive(false);
        ballSettingsButton.SetActive(false);
        settingsButton.SetActive(false);
        tapToPlayText.gameObject.SetActive(false);
        GameController.Instance.canShoot = true;
    }

    public void TapToPause()
    {
        GameController.Instance.enabled = false;
        pausePanel.DOColor(new Color(colorController.currentImagesColor.r,colorController.currentImagesColor.g,colorController.currentImagesColor.b,1), 0.3f).SetEase(Ease.Linear); 
        playButton.SetActive(true);
        ballSettingsButton.SetActive(true);
        settingsButton.SetActive(true);
        tapToPlayText.gameObject.SetActive(true);
    }

    private void ChangeTextColor()
    {
        tapToPlayText.DOColor(new Color(colorController.currentTextColor.r,colorController.currentTextColor.g,colorController.currentTextColor.b,tapToPlayText.color.a),
            0.3f).SetEase(Ease.Linear);
    }
}
