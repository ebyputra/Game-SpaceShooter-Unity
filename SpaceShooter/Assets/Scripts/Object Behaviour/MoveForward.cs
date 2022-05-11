using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MoveForward : MonoBehaviour
{
    private Moveable moveable;
    private void Awake()
    {
        moveable = GetComponent<Moveable>();
    }

    void Update()
    {
        moveable.SetDirection(transform.up);
    }
}
