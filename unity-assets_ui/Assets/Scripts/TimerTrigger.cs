using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player triggered");
            other.gameObject.GetComponent<Timer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
