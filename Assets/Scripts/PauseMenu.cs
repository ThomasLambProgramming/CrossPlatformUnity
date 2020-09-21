using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    bool hasFailed = false;
    public GameObject failMenu;
    public GameObject androidMenu;
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            androidMenu.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameIsPaused == true && hasFailed == false)
            {
                Resume();
            }
            else if (hasFailed == false)
            {
                Pause();
            }
        }
    }
    public void LoadFail()
    {
        Time.timeScale = 0f;
        failMenu.SetActive(true);
        GameIsPaused = true;
        hasFailed = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }
    public void Pause()
    {
       
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        hasFailed = false;
    }
}
