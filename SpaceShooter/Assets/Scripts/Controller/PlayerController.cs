using System;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class PlayerController: MonoBehaviour
{
    public InputHandler inputHandler;
    private Moveable moveable;
    private void Awake()
    {
       moveable = GetComponent<Moveable>();
    }

    private void Start()
    {
        
    }

    private void OnSetDirection(Vector2 direction)
    {
        // Debug.Log(direction);
        moveable.SetDirection(direction);
    }

    private void OnEnable()
    {
        inputHandler.OnMoveAction += OnSetDirection;
    }

    private void OnDisable()
    {
        inputHandler.OnMoveAction -= OnSetDirection;
    }
}