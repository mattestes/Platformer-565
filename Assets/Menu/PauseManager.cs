using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // makes the pause menu visible
            pausePanel.SetActive(true);
            // makes the cursor visible
            Cursor.lockState = CursorLockMode.None;
            // freezes the game, ie player movement and probably other stuff once we add it
            Time.timeScale = 0;
        }
    }

    public void unpause()
    {
        // hides the pause menu again
        pausePanel.SetActive(false);
        // hides/locks the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        // unfreezes the game
        Time.timeScale = 1;
    }

    public void LoadScene(string sceneName)
    {
        // need to unfreeze the game here; otherwise it will still be frozen if the player returns
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
