using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject nextLevelButton;
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            //levelManager.StartLevel();
        }
    }

    public void Pause()
    {
        // makes the pause menu visible
        pausePanel.SetActive(true);
        nextLevelButton.SetActive(levelManager.currentComplete());
        // makes the cursor visible
        Cursor.lockState = CursorLockMode.None;
        // freezes the game, ie player movement and probably other stuff once we add it
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        // hides the pause menu again
        pausePanel.SetActive(false);
        // hides/locks the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        // unfreezes the game
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        levelManager.StartLevel();
        Unpause();
    }

    public void NextLevel()
    {
        levelManager.NextLevel();
        Unpause();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        // makes the cursor visible
        Cursor.lockState = CursorLockMode.None;
        // freezes the game, ie player movement and probably other stuff once we add it
        Time.timeScale = 0;
    }

    public void LoadScene(string sceneName)
    {
        // need to unfreeze the game here; otherwise it will still be frozen if the player returns
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
