using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _ballRigidbody;
    private CircleCollider2D _ballCollider;

    public Vector3 ballPosition { get; private set; }

    private void Awake()
    {
        _ballCollider = GetComponent<CircleCollider2D>();
        _ballRigidbody = GetComponent<Rigidbody2D>();
        ballPosition = transform.position;
    }

    public void Push(Vector2 force)
    {
        _ballRigidbody.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        _ballRigidbody.isKinematic = false;
    }

    public void DeactivateRb()
    {
        ballPosition = transform.position;
        _ballRigidbody.velocity = Vector3.zero;
        _ballRigidbody.angularVelocity = 0f;
        _ballRigidbody.isKinematic = true;
    }
}
