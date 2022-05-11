using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireRateModifier : MonoBehaviour
{
    public float modifier = 0.2f;
    private List<Weapon> _weapons;

    private void Awake()
    {
        _weapons = GetComponentsInChildren<Weapon>().ToList<Weapon>();
    }
    void Start()
    {
        foreach (Weapon w in _weapons)
        {
            w.AddFireRateModifier(modifier);
        }
    }

    void Update()
    {

    }

    private void OnDestroy()
    {
        foreach (Weapon w in _weapons)
        {
            w.RemoveFireRateModifier(modifier);
        }
    }

    public void AddComponentToObject(GameObject go)
    {
        go.AddComponent<FireRateModifier>();
        go.GetComponent<WeaponSetController>().WeaponUpgradeCheck();
    }
}