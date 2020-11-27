using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Scene set up")]
    public Camera playerCamera;
    [SerializeField] Transform groundChecker;
    [SerializeField] float groundCheckRadius = 0.2f;

    [Header("Stats")]
    public float walkingSpeed = 7.5f;

    [Header("Camera")]
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    [SerializeField] bool canMove = true;
    [SerializeField] public ETeam team;

    //private
    private Rigidbody body;
    private Vector3 inputs = Vector3.zero;
    private bool isGrounded = true;

    internal Vector3 xyMove = Vector3.zero;
    private float rotationX = 0;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Update state
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckRadius, GameManager.Instance.groundLayer, QueryTriggerInteraction.Ignore);

        //Update Axis
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");

        Vector3 lookDirection = playerCamera.transform.TransformDirection(Vector3.forward);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = walkingSpeed * inputs.x;
        float curSpeedZ = walkingSpeed * inputs.z;
        xyMove = (forward * curSpeedZ) + (right * curSpeedX);

        //Apply gravity
        //if (!isGrounded)
        //    moveDirection.y -= gravity * Time.deltaTime;

        //Camera 
        Rotate();
    }

    void FixedUpdate()
    {
        if (canMove)
            body.MovePosition(body.position + xyMove * Time.fixedDeltaTime);
    }

    public void TakeHit()
    {

    }

    private void Rotate()
    {
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckRadius);
    }

}
