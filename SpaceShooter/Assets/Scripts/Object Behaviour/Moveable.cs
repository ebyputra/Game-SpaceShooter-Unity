using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    private void Start()
    {
        
    }
    
    void Update()
    {
        UpdatePosition();
    }
    
    private void UpdatePosition()
    {
        transform.position += NewPosition();
    }

    public Vector3 GetNextPosition()
    {
        return transform.position + NewPosition();
    }

    public Vector3 NewPosition()
    {
        return direction * (Time.deltaTime * speed);
    }

    internal void SetXDirection(float xValue)
    {
        direction.x = xValue;
    }

    internal void SetYDirection(float yValue)
    {
        direction.y = yValue;
    }

    public void SetDirection(Vector3 value)
    {
        direction = value;
    }

    public void SetDirection(Vector2 value)
    {
        direction.x = value.x;
        direction.y = value.y;
    }
    internal void SetDirection(float x, float y)
    {
        direction.x = x;
        direction.y = y;
    }
}