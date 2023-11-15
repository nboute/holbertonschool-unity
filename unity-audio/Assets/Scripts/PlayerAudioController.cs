using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public PlayerController playerController;
    private AudioSource runningSound;
    private AudioSource fallingSound;
    public AudioSource grassRunning;
    public AudioSource rockRunning;
    public AudioSource grassFalling;
    public AudioSource rockFalling;

    // Start is called before the first frame update
    void Start()
    {
        runningSound = grassRunning;
        fallingSound = grassFalling;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAudioByTag(string tag)
    {
        if (tag == "Grass")
        {
            fallingSound = grassFalling;
            runningSound = grassRunning;
        }
        else if (tag == "Rock")
        {
            fallingSound = rockFalling;
            runningSound = rockRunning;
        }
    }

    public void StartRunning()
    {
        if (playerController.isGrounded == true)
            runningSound.Play();
    }

    public void PlayFallingSound()
    {
        fallingSound.Play();
    }

    public void LockInput(int state)
    {
        playerController.LockInput(state);
    }
}
