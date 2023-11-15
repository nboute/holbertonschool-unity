using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;
    public Animator animator;
    public string animName;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger(animName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IntroEnd()
    {
        mainCamera.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
        timerCanvas.SetActive(true);
        gameObject.SetActive(false);
        animator.ResetTrigger(animName);
    }
}
