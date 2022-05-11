using System;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MovementBoundary : MonoBehaviour
{
    public Rect boundary;
    private Moveable _moveable;

    private void Awake()
    {
        _moveable = GetComponent<Moveable>();
    }

    private void Start()
    {
        
    }

    void Update()
    {
        if (IsXOutBoundary())
        {
            _moveable.SetXDirection(0f);
        }

        if (IsYOutBoundary())
        {
            _moveable.SetYDirection(0f);
        }
    }

    private bool IsYOutBoundary()
    {
        return _moveable.GetNextPosition().y < boundary.yMin || _moveable.GetNextPosition().y > boundary.yMax;
    }

    private bool IsXOutBoundary()
    {
        return _moveable.GetNextPosition().x < boundary.xMin || _moveable.GetNextPosition().x > boundary.xMax;
    }
}