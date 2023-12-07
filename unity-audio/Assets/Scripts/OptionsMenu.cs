using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    private SceneHistoryManager sceneHistoryManager;
    private bool YToggleValue = false;
    public Toggle toggle;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    
    void Start()
    {
        YToggleValue = PlayerPrefs.GetInt("CameraYInvert") == 1;
        toggle.isOn = YToggleValue;
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sceneHistoryManager = FindObjectOfType<SceneHistoryManager>();
        SetVolume();
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
        PlayerPrefs.SetInt("CameraYInvert", YToggleValue ? 1 : 0);
        PlayerPrefs.SetFloat("BGMVolume", bgmSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.Save();
    }

    public void SetVolume()
    {
        float bgmValue = bgmSlider.value;
        float sfxValue = sfxSlider.value;
        audioMixer.SetFloat("BgmVolume", bgmValue != 0 ? Mathf.Log10(bgmValue) * 20 : -80f);
        sfxValue = sfxValue != 0 ? Mathf.Log10(sfxValue) * 20 : -80f;
        audioMixer.SetFloat("AmbVolume", sfxValue);
        audioMixer.SetFloat("RunVolume", sfxValue);
        audioMixer.SetFloat("LandVolume", sfxValue);
    }

}
