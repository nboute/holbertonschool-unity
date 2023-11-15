using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameCamera;
    public GameObject winMenu;
    private SceneHistoryManager sceneHistoryManager;
    public AudioMixerSnapshot pausedAudioSnapshot;
    public AudioMixerSnapshot unpausedAudioSnapshot;

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
        pausedAudioSnapshot.TransitionTo(0.0f);
        gameCamera.GetComponent<CameraController>().isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        unpausedAudioSnapshot.TransitionTo(0.0f);
        gameCamera.GetComponent<CameraController>().isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        unpausedAudioSnapshot.TransitionTo(0.0f);
        Debug.Log("Hello");
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        sceneHistoryManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        unpausedAudioSnapshot.TransitionTo(0.0f);
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
