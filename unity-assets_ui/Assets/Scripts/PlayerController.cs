using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameObject playerCamera;
    public float speed = 10f;
    public float jumpForce = 10f;
    private Rigidbody rb;
    public bool isJumping = false;
    private Collider playerCollider;
    private float distToGround;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        distToGround = playerCollider.bounds.extents.y;
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y < -20)
        {
            playerTransform.position = new Vector3(0, 10, 0);
            playerCamera.GetComponent<CameraController>().ResetOffset();
            rb.velocity = Vector3.zero;
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * 15.0f);
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        var forward = Input.GetAxis("Vertical");
        var right = Input.GetAxis("Horizontal");
        var moveDirection = (transform.forward * forward) + (transform.right * right);
        moveDirection = moveDirection.normalized;
        rb.AddForce(moveDirection * speed);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}
