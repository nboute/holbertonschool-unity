using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    private SceneHistoryManager sceneHistoryManager;
    public AudioMixer audioMixer;
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        sceneHistoryManager = FindObjectOfType<SceneHistoryManager>();
        DontDestroyOnLoad(bgm);
        LoadPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        int numBgmPlayers = GameObject.FindGameObjectsWithTag("BGM").Length;
        Debug.Log(numBgmPlayers);
        if (numBgmPlayers > 1)
            Destroy(bgm.gameObject);
    }
    public void LevelSelect(int level)
    {
        //load scene
        var bgm = GameObject.FindWithTag("BGM");
        if (bgm != null)
            Destroy(bgm);
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

    private void LoadPlayerPrefs()
    {
        var YToggle = PlayerPrefs.GetInt("CameraYInvert") == 1;
        var bgm = PlayerPrefs.GetFloat("BGMVolume", 1f);
        var sfx = PlayerPrefs.GetFloat("SFXVolume", 1f);
        audioMixer.SetFloat("BgmVolume", bgm != 0 ? Mathf.Log10(bgm) * 20 : -80f);
        sfx = sfx != 0 ? Mathf.Log10(sfx) * 20 : -80f;
        audioMixer.SetFloat("AmbVolume", sfx);
        audioMixer.SetFloat("RunVolume", sfx);
        audioMixer.SetFloat("LandVolume", sfx);
    }
}
