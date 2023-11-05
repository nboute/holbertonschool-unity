using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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

    public void LevelSelect(int level)
    {
        //load scene
        sceneHistoryManager.LoadScene($"Level{level:00}");
    }

    public void Options()
    {
        sceneHistoryManager.LoadScene("Options");
    }

    public void Exit()
    {
        Debug.Log("Quit");
        //quit game
        Application.Quit();
    }
}
