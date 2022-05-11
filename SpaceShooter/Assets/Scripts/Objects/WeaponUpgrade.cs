using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
        
    void Start()
    {
        
    }
        
    void Update()
    {
        
    }

    public void AddComponentToObject(GameObject go)
    {
        go.AddComponent<WeaponUpgrade>();
        go.GetComponent<WeaponSetController>().WeaponUpgradeCheck();
    }
        
}
