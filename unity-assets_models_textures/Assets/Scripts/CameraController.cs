using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 velocity;
    public float timeOffset = 0.3f;
    public Vector3 initialOffset = new Vector3(0, 1, -5);
    private Vector3 offset;
    public float horizontalSensitivity = 3.0f;
    public float verticalSensitivity = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position + offset;
        offset = initialOffset;
    }

    public void ResetOffset()
    {
        offset = initialOffset;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, timeOffset);
        float rotateHorizontal = Input.GetAxis("Mouse X") * horizontalSensitivity;
        float rotateVertical = Input.GetAxis("Mouse Y") * verticalSensitivity;

        offset = Quaternion.Euler(0, rotateHorizontal, 0) * Quaternion.Euler(-rotateVertical, 0, 0) * offset;
        transform.RotateAround(player.position, Vector3.up, rotateHorizontal);
        transform.RotateAround(player.position, -transform.right, rotateVertical);
        transform.LookAt(player.position);
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate() {

    }
}
