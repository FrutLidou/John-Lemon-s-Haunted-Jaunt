using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControl : MonoBehaviour
{
    public Camera menuCam;
    public Camera gameCam;
    public GameObject player;
    public GameObject mainMenu;
    public GameObject controlsMenu;
    public GameObject pauseMenu;

    public void startGame()
    {
        this.gameObject.SetActive(false);
        menuCam.enabled = false;
        gameCam.enabled = true;
        pauseMenu.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void goToControls()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void backToMainMenu()
    {
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
