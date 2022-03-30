using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;
    private bool m_isPaused = false;
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public KeyItem keyItem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_isPaused)
            {
                unpauseGame();
            }
            else
            {
                pauseGame();
            }
            m_isPaused = !m_isPaused;
        }
    }

    public void backToGame()
    {
        unpauseGame();
    }

    public void goToControls()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void backToPause()
    {
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
        unpauseGame();
    }

    private void pauseGame()
    {
        keyItem.pauseAnimation();
        pauseCanvas.enabled = true;
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    private void unpauseGame()
    {
        keyItem.resumeAnimation();
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
