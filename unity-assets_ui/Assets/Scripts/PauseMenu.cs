using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameCamera;
    public GameObject winMenu;
    private SceneHistoryManager sceneHistoryManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneHistoryManager = FindObjectOfType<SceneHistoryManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (winMenu.activeInHierarchy == true)
                return;
            if (pauseMenu.activeInHierarchy == true)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        gameCamera.GetComponent<CameraController>().isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        gameCamera.GetComponent<CameraController>().isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Debug.Log("Hello");
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        sceneHistoryManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        sceneHistoryManager.LoadScene("MainMenu");
    }

    public void OptionsMenu()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        sceneHistoryManager.LoadScene("Options");
    }
}
