using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
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

    public void Back()
    {
        string prevScene = sceneHistoryManager.GetPreviousScene() ?? "MainMenu";
        SceneManager.LoadScene(prevScene);
    }
}
