using UnityEngine;

public class WeaponSetController : MonoBehaviour
{
    public GameObject[] weaponSet;
    // Start is called before the first frame update
    void Start()
    {
        DeactivateAllWeapons();
        ActivateWeaponSet(1);
        WeaponUpgradeCheck();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DeactivateAllWeapons()
    {
        foreach (GameObject go in weaponSet)
        {
            go.SetActive(false);
        }
    }

    public void ActivateWeaponSet(int setNumber)
    {
        for (int i = 0; i < weaponSet.Length; i++)
        {
            if (i == setNumber)
            {
                weaponSet[i].SetActive(true);
            }
            else
            {
                weaponSet[i].SetActive(false);
            }
        }
    }

    public void WeaponUpgradeCheck()
    {
        int upgradeLevel = GetComponents<WeaponUpgrade>().Length;

        if (upgradeLevel >= weaponSet.Length)
        {
            upgradeLevel = weaponSet.Length - 1;
        }

        ActivateWeaponSet(upgradeLevel);
        FireRateUpdate();
    }
    private void FireRateUpdate()
    {
        foreach (Weapon weapon in GetComponentsInChildren<Weapon>())
        {
            weapon.ClearModifier();
            foreach (FireRateModifier fireRateModifier in GetComponents<FireRateModifier>())
            {
                weapon.RemoveFireRateModifier(fireRateModifier.modifier);
            }
        }
    }
}