using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controlsMenu;

    public void startGame()
    {
        SceneManager.LoadScene(1);
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
