using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHistoryManager : MonoBehaviour
{
    private static SceneHistoryManager instance;
    private string lastScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPreviousScene(string sceneName)
    {
        lastScene = sceneName;
    }

    public string GetPreviousScene()
    {
        return lastScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        SetPreviousScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }
}
