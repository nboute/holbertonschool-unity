using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timeSpan = 0f;
    public GameObject WinCanvasTimerText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSpan += Time.deltaTime;
        TimeSpan currentTime = TimeSpan.FromSeconds(timeSpan);
        string formattedTime = $"{currentTime:mm\\:ss\\.ff}";
        timerText.text = formattedTime;
    }

    // Called when the player touches the win flag
    public void Win()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        TimeSpan currentTime = TimeSpan.FromSeconds(timeSpan);
        string formattedTime = $"{currentTime:mm\\:ss\\.ff}";
        WinCanvasTimerText.GetComponent<TextMeshProUGUI>().text = formattedTime;
    }
}
