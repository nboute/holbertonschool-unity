using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 velocity;
    public float timeOffset = 0.03f;
    public Vector3 initialOffset = new Vector3(0, 1, -5);
    private Vector3 offset;
    public float horizontalSensitivity = 3.0f;
    public float verticalSensitivity = 3.0f;
    [HideInInspector]
    public bool isPaused;
    public bool isInverted = false;
    public bool lockInput = false;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        transform.position = player.position + offset;
        offset = initialOffset;
    }

    void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt("CameraYInvert"));
        isInverted = PlayerPrefs.GetInt("CameraYInvert") == 1 ? true : false;
    }

    public void ResetOffset()
    {
        offset = initialOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
            return;
        //transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, timeOffset);
        transform.position = player.position + offset;
        float rotateHorizontal = Input.GetAxis("Mouse X") * horizontalSensitivity;
        float rotateVertical = Input.GetAxis("Mouse Y") * verticalSensitivity;
        if (isInverted)
            rotateVertical *= -1f;

        offset = Quaternion.Euler(0, rotateHorizontal, 0) * Quaternion.Euler(-rotateVertical, 0, 0) * offset;
        transform.RotateAround(player.position, Vector3.up, rotateHorizontal);
        transform.RotateAround(player.position, -transform.right, rotateVertical);
        float cameraRotation = transform.eulerAngles.y;
        transform.LookAt(player.position);
        if (lockInput)
            return;
        Vector3 inputDIrection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (inputDIrection != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(inputDIrection.x, inputDIrection.z) * Mathf.Rad2Deg + cameraRotation;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            player.rotation = Quaternion.Slerp(player.rotation, targetRotation, 0.1f);
        }
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate() {

    }
}
