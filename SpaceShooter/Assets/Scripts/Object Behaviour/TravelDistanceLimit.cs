using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class TravelDistanceLimit : MonoBehaviour
{
    public float maxTravelDistance;
    private float travelDistance;
    private Moveable moveable;
    private PoolObject poolObject;

    private void Awake()
    {
        moveable = GetComponent<Moveable>();
        poolObject = GetComponent<PoolObject>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (travelDistance >= maxTravelDistance)
        {
            if (poolObject != null)
            {
                poolObject.Deactivate();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        travelDistance += moveable.NewPosition().magnitude;
    }

    private void OnEnable()
    {
        travelDistance = 0;
    }
}