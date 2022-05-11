using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public InputHandler inputHandler;
    
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    
    void Start()
    {
        GameManager.GetInstance().OnGameOverAction += GameOver;  
    }
    
    void Update()
    {
        
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        GameManager.GetInstance().PauseGame();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        GameManager.GetInstance().ResumeGame(); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void Retry()
    {
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(true);
        GameManager.GetInstance().Retry();
    }
        
    private void OnEnable()
    {
        inputHandler.OnPauseAction += PauseGame;
    }

    private void OnDisable()
    {
        inputHandler.OnPauseAction -= PauseGame;    
    }
}
