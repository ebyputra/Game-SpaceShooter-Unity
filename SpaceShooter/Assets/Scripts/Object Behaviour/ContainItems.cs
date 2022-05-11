using System.Collections.Generic;
using UnityEngine;

public class ContainItems : MonoBehaviour
{
    public List<ObjectSpawnRate> objects;
    void Start()
    {

    }

    void Update()
    {

    }

    public void SpawnItemOnDeath()
    {
        GameObject go = GetItem();
        if (go != null)
        {
            GameManager.GetInstance().AddItem(Instantiate(go, transform.position, Quaternion.identity));
        }
    }
    private GameObject GetItem()
    {
        int limit = 0;

        foreach (ObjectSpawnRate osr in objects)
        {
            limit += osr.rate;
        }

        int random = Random.Range(0, limit);

        foreach (ObjectSpawnRate osr in objects)
        {
            if (random < osr.rate)
            {
                return osr.prefab;
            }
            else
            {
                random -= osr.rate;
            }
        }
        return null;
    }
}