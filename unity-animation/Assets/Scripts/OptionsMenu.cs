using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private SceneHistoryManager sceneHistoryManager;
    private bool YToggleValue = false;
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        YToggleValue = PlayerPrefs.GetInt("CameraYInvert") == 1;
        Debug.Log(YToggleValue);
        toggle.isOn = YToggleValue;
        sceneHistoryManager = FindObjectOfType<SceneHistoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        string prevScene = sceneHistoryManager?.GetPreviousScene() ?? "MainMenu";
        SceneManager.LoadScene(prevScene);
    }

    public void InvertY()
    {
        YToggleValue = toggle.isOn;
    }
    public void Save()
    {
        Debug.Log(YToggleValue);
        PlayerPrefs.SetInt("CameraYInvert", YToggleValue ? 1 : 0);
    }
}
