using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameObject playerCamera;
    public float speed = 10f;
    public float jumpForce = 10f;
    private Rigidbody rb;
    public bool isJumping = false;
    private Collider playerCollider;
    public bool isGrounded = true;
    private Transform playerTransform;
    public Animator animator;
    public PlayerAudioController playerAudioController;
    private bool lockInput = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float xForce = rb.velocity.x;
        float zForce = rb.velocity.z;
        float magnitude = new Vector2(xForce, zForce).magnitude;

        isGrounded = IsGrounded();
        if (isGrounded)
        {
            animator.ResetTrigger("Falling");
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("IsJumping", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (playerTransform.position.y < -40)
        {
            playerTransform.position = new Vector3(0, 10, 0);
            playerCamera.GetComponent<CameraController>().ResetOffset();
            rb.velocity = Vector3.zero;
            animator.SetTrigger("Falling");
        }
        else if (playerTransform.position.y < -10)
        {
            animator.SetTrigger("Falling");
        }
        animator.SetBool("IsRunning", isGrounded && (Mathf.Abs(xForce) > 0.1f) || (Mathf.Abs(zForce) > 0.1f));
        animator.SetBool("IsJumping", !isGrounded);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Grass" || other.gameObject.tag == "Rock")
            playerAudioController.SetAudioByTag(other.gameObject.tag);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * 15.0f);
        if (isGrounded && !lockInput)
        {
            var forward = Input.GetAxis("Vertical");
            var right = Input.GetAxis("Horizontal");
            var cameraForward = new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z).normalized;
            var cameraRight = new Vector3(playerCamera.transform.right.x, 0, playerCamera.transform.right.z).normalized;
            var moveDirection = (cameraForward * forward) + (cameraRight * right);
            moveDirection = moveDirection.normalized;
            rb.AddForce(moveDirection * speed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    public void LockInput(int state)
    {
        if (state == 1)
        {
            Debug.Log("Locking input");
            lockInput = true;
            playerCamera.GetComponent<CameraController>().lockInput = true;
        }
        else
        {
            Debug.Log("Unlocking input");
            lockInput = false;
            playerCamera.GetComponent<CameraController>().lockInput = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.25f);
    }

}
