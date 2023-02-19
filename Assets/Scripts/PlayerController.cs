using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 rawInput;
    [SerializeField] private float moveSpeed = 8f;

    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;

    private Shooter shooter;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    private void Awake()
    {
        this.shooter = GetComponent<Shooter>();
    }

    private void Start() 
    {
        this.InitBounds();    
    }

    private void Update()
    {
        this.Move();
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main;
        this.minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        this.maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        Vector2 delta = this.rawInput * this.moveSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(this.transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPosition.y = Mathf.Clamp(this.transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        this.transform.position = newPosition;
    }

    private void OnMove(InputValue value)
    {
        this.rawInput = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        if (this.shooter != null)
        {
            this.shooter.isFiring = value.isPressed;
        }
    }
}
