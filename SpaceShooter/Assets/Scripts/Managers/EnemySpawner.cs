using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float delay;
    public ObjectSpawnRate[] enemies;

    private List<GameObject> enemyList;
    
    void Start()
    {
        enemyList = new List<GameObject>();
        
        StartCoroutine(Spawner());
    }
    
    void Update()
    {

    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            if (GameManager.GetInstance().isPlay)
            {
                spawn();
                yield return new WaitForSeconds(delay);
            }
            else
            {
                yield return null;
            }
        }
    }

    private GameObject GetEnemy()
    {
        int limit = 0;

        foreach (ObjectSpawnRate osr in enemies)
        {
            limit += osr.rate;
        }

        int random = Random.Range(0, limit);

        foreach (ObjectSpawnRate osr in enemies)
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

    private void spawn()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(-7.5f, 7.5f);

        enemyList.Add(Instantiate(GetEnemy(), newPosition, transform.rotation));
    }

    public void ClearEnemy()
    {
        foreach (GameObject go in enemyList)
        {
            Destroy(go);
        }
        enemyList.Clear();
    }
}