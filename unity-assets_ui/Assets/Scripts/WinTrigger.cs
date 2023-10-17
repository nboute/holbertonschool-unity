using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text winText;
    public GameObject winCanvas;
    public GameObject gameCamera;
    public GameObject player;

    private SceneHistoryManager sceneHistoryManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneHistoryManager = FindObjectOfType<SceneHistoryManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player triggered");
            Time.timeScale = 0;
            winText.fontSize = 60;
            winText.color = Color.green;
            winText.enabled = false;
            winCanvas.SetActive(true);
            gameCamera.GetComponent<CameraController>().isPaused = true;
            player.GetComponent<Timer>().Win();
        }
    }

    public void MainMenu()
    {
        sceneHistoryManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Level01")
            sceneHistoryManager.LoadScene("Level02");
        else if (currentScene == "Level02")
            sceneHistoryManager.LoadScene("Level03");
        else
            sceneHistoryManager.LoadScene("MainMenu");
    }
}
