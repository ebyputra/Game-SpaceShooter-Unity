using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate;
    public List<float> fireRateModifiers;
    private float _timer;
    public PoolObjectType type;

    private void Awake()
    {
        _timer = 0;
    }

    private void Start()
    {
        fireRateModifiers = new List<float>();
    }
    void Update()
    {
        _timer = _timer - Time.deltaTime > 0 ? _timer - Time.deltaTime : 0f;
    }

    public void Shoot()
    {
        if (_timer == 0f)
        {
            // Debug.Log("fire!");
            // ReSharper disable once Unity.InefficientPropertyAccess
            ObjectPool.GetInstance().RequestObject(type).Activate(transform.position, transform.rotation);
            _timer = fireRate / GetFireRateModifier();
        }
    }
    private float GetFireRateModifier()
    {
        float mod = 1;
        foreach (float f in fireRateModifiers)
        {
            mod += f;
        }
        return mod;
    } 
        
    internal void AddFireRateModifier(float modifier)
    {
        fireRateModifiers.Add(modifier);
    }
        
    internal void RemoveFireRateModifier(float modifier)
    {
        fireRateModifiers.Remove(modifier);
    }
    internal void ClearModifier()
    {
        fireRateModifiers.Clear();
    }
}