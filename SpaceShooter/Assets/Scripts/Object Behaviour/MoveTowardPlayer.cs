using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MoveTowardPlayer : MonoBehaviour
{
    private Moveable moveable;

    private void Awake()
    {
        moveable = GetComponent<Moveable>();
    }
    
    void Start()
    {
        moveable.SetDirection(GetDirection());
    }
    
    void Update()
    {
        
    }

    private Vector3 GetDirection()
    {
        var dir = GameManager.GetInstance().GetPlayerPosition() - transform.position;
        dir = dir.normalized;

        return dir;
    }
}
