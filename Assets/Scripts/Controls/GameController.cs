using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private Camera _camera;
    [SerializeField] private Ball ball;
    [field: SerializeField] public Trajectory trajectory { get; private set; }
    [SerializeField] private float pushForce;

    private bool _isDragging;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private Vector2 force;
    private float distance;

    public bool canShoot;

    private void Start()
    {
        _camera = Camera.main;
        ball.DeactivateRb();
        canShoot = true;

        EventManager.OnBallInBasket += AllowBallShoot;
        EventManager.OnGameEnded += DeactivateShooting;
        EventManager.OnGameRestart += ActivateShooting;
        EventManager.OnGameRestart += BallOnRestart;
    }

    private void DeactivateShooting()
    {
        this.enabled = false;
    }

    private void ActivateShooting()
    {
        this.enabled = true;
    }

    private void Update()
    {
        if (canShoot)
        { 
            if (Input.GetMouseButtonDown(0))
            { 
                _isDragging = true;
                OnDragStart();
            }
            if (Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
                OnEndDrag();
            }
            if (_isDragging)
            {
                OnDrag();
            }
        }
    }

    private void OnDragStart()
    {
        ball.DeactivateRb();
        startPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        trajectory.ShowTrajectory();
    }

    private void OnDrag()
    {
        endPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;
        trajectory.UpdateDots(ball.ballPosition, force);
    }

    private void OnEndDrag()
    {
        ball.ActivateRb();
        ball.Push(force);
        trajectory.HideTrajectory();
        canShoot = false;
    }

    private void AllowBallShoot()
    {
        canShoot = true;
    }

    private void BallOnRestart()
    {
        ball.DeactivateRb();
        endPoint = Vector2.zero;
        startPoint = Vector2.zero;
        force = Vector2.zero;
        direction = Vector2.zero;
        AllowBallShoot();
    }
    
}
