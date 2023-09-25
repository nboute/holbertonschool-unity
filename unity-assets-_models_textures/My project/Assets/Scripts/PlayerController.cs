using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] GameObject playerCamera;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnLook(InputValue rot)
    {
        Vector2 inputRot = rot.Get<Vector2>();
        Vector3 camRot = playerCamera.transform.rotation.eulerAngles;
        camRot.x += inputRot.y;
        camRot.y -= inputRot.x;
        playerCamera.transform.rotation = Quaternion.Euler(camRot);
    }

    void OnMove()
    {
        Debug.Log("Moved");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
