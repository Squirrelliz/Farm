using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    public bool pauseGame;
    [SerializeField] GameObject pauseGameMenu;
    [SerializeField] GameObject musicManager;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (pauseGame == false)
            {
            
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseGame = true;

    }

    public void Music()
    {
        musicManager.SetActive(!musicManager.activeInHierarchy);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
