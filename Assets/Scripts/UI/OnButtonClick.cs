using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
    private Vector3 defaultScale = new Vector3(1,1,1);
    private AudioSource _source;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        _source = FindObjectOfType<AudioSource>();
    }

    public void OnClick()
    {
        _source.PlayOneShot(clip);
        transform.DOScale(defaultScale - Vector3.one * 0.08f, 0.1f).SetLoops(2, LoopType.Yoyo).From(defaultScale).SetEase(Ease.Linear);
    }
}
