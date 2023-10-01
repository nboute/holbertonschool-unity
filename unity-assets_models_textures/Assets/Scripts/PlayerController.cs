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
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Move(1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(-1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(0, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(0, -1);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void Move(short forward, short right)
    {
        Vector3 movementDirection = Vector3.zero;
        if (forward == 1)
        {
            movementDirection += playerCamera.transform.forward;
        }
        else if (forward == -1)
        {
            movementDirection -= playerCamera.transform.forward;
        }
        if (right == 1)
        {
            movementDirection -= playerCamera.transform.right;
        }
        else if (right == -1)
        {
            movementDirection += playerCamera.transform.right;
        }

        if (movementDirection.magnitude > 1)
        {
            movementDirection.Normalize();
        }

        Vector3 movement = movementDirection * speed;
        rb.AddForce(movement);
    }
}
