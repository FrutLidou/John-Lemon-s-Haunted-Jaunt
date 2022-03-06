using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;
    private bool m_isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_isPaused)
            {
                //Enable key animation
                pauseCanvas.enabled = true;
                Time.timeScale = 1;
                AudioListener.pause = false;
            }
            else
            {
                //Disable key animation
                pauseCanvas.enabled = true;
                Time.timeScale = 0;
                AudioListener.pause = true;
            }
            m_isPaused = !m_isPaused;
        }
    }
}
