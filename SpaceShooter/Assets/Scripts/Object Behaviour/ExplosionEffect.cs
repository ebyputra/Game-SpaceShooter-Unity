using Unity.Mathematics;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public void ShowExplosion()
    {
        ObjectPool.GetInstance().RequestObject(PoolObjectType.Explosion)
            .Activate(transform.position, quaternion.identity);
    }
}