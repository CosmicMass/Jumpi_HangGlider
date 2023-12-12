using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Joystick joystick;

    public float forwardSpeed = 15f;
    public float horizontalSpeed = 4f;
    public float verticalSpeed = 4f;

    public float maxHorizontalRotation = 0.1f;
    public float maxVerticalRotation = 0.06f;

    public float smoothness = 5f;
    public float rotationSmoothness = 5f;

    Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;

    private float forwardSpeedMultiplier = 100f;
    private float speedMultiplier = 1000f;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        //Inputs
        if (Input.GetMouseButtonDown(0) || Input.touches.Length != 0)
        {
            horizontalInput = joystick.Horizontal;
            verticalInput = joystick.Vertical;
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        HandlePlaneRotation();
            
    }

    private void FixedUpdate()
    {
        HandlePlaneMovement();
    }

    private void HandlePlaneMovement()
    {
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardSpeed * forwardSpeedMultiplier * Time.deltaTime);

        float xVelocity = horizontalInput * speedMultiplier * horizontalSpeed * Time.deltaTime;
        float yVelocity = -verticalInput * speedMultiplier * verticalSpeed * Time.deltaTime;

        rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(xVelocity, yVelocity, rb.velocity.z), Time.deltaTime * smoothness);

    }
    private void HandlePlaneRotation()
    {
        float horizontalRotation = -horizontalInput * maxHorizontalRotation;
        float verticalRotation = verticalInput * maxVerticalRotation;

        transform.rotation = Quaternion.Lerp(
            transform.rotation, new Quaternion(verticalRotation, transform.rotation.y, horizontalRotation, transform.rotation.w), Time.deltaTime * rotationSmoothness);
    }

}
