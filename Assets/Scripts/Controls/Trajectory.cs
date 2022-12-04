using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private int dotsNumber;
    [SerializeField] private GameObject dotsParent;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private float dotSpacing;

    [Range(0.01f, 0.1f)]
    [SerializeField] private float dotMinimalScale;
    [Range(0.1f, 0.3f)] 
    [SerializeField] private float dotMaximumScale;

    private Vector2 position;
    private Transform[] dotsList;
    private float timeStamp;

    private void Start()
    {
        HideTrajectory();
        PrepareDots();
    }

    public void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];

        dotPrefab.transform.localScale = Vector3.one * dotMaximumScale;

        float scale = dotMaximumScale;
        float scaleFactor = scale / dotsNumber;
        for (int i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotPrefab, null).transform;
            dotsList[i].parent = dotsParent.transform;
            
            dotsList[i].localScale = Vector3.one * scale;
            if (scale > dotMinimalScale)
            {
                scale -= scaleFactor;
            }
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 force)
    {
        timeStamp = dotSpacing;
        for (int i = 0; i < dotsNumber; i++)
        {
            position.x = (ballPos.x + force.x * timeStamp);
            position.y = (ballPos.y + force.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2;

            dotsList[i].position = position;
            timeStamp += dotSpacing;
        }
    }

    public void ShowTrajectory()
    {
        dotsParent.SetActive(true);
    }

    public void HideTrajectory()
    {
        dotsParent.SetActive(false);
    }
}
