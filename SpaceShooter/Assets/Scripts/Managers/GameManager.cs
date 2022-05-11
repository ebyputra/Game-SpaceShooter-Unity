using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    
    public GameObject playerPrefab;
    public GameObject activePlayer;

    public ScriptableInteger life;
    public ScriptableInteger coin;
    public EnemySpawner Spawner;

    public List<GameObject> items;
    
    public bool isPlay = false;
    
    public UnityAction OnGameOverAction;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
    
    void Start()
    {
        items = new List<GameObject>();
    }
    private void SpawnPlayer()
    {
        activePlayer = Instantiate(playerPrefab);
    }
        
    public Vector3 GetPlayerPosition()
    {
        return activePlayer != null ? activePlayer.transform.position : Vector3.zero;
    }

    public void StartGame()
    {
        isPlay = true;
        SpawnPlayer();
    }

    public void PauseGame()
    {
        isPlay = false;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        isPlay = true;
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        isPlay = false;
        OnGameOverAction?.Invoke();  
    }
    public void Retry()
    {
        life.Reset();
        coin.Reset();
        Spawner.ClearEnemy();
        ObjectPool.GetInstance().DeactivateAllObject();
        ClearAllItems();
    }
    public void AddItem(GameObject go)
    {
        items.Add(go);
    }

    public void ClearAllItems()
    {
        foreach (GameObject gameObject in items)
        {
            Destroy(gameObject);
        }
        items.Clear();
    }
}