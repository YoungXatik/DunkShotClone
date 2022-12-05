using System;
using UnityEngine;
public class LockCameraZ : MonoBehaviour
{
    [SerializeField] private float followOffset;

    public Transform ball;
    private Transform _cameraTransform;

    private void Start()
    {
        _cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (ball != null)
        {
            float yPos = ball.position.y + followOffset;
            _cameraTransform.position = new Vector3(0, yPos + followOffset, 0);
        }
        else
        {
            return;
        }
    }
}