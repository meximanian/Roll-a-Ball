using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject panel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Roll-a-Ball");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
        AudioListener.pause = false;
        panel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Roll-a-Ball");
        Time.timeScale = 1;
        AudioListener.pause = false;
        panel.SetActive(false);
    }
}
