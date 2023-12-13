using UnityEngine;

public class DeltaController : MonoBehaviour
{
    public static DeltaController Instance;
    public Joystick joystick;

    public float FlySpeed = 120;
    public float YawAmount = 60;

    private float horizontalInput;
    private float verticalInput;
    private float Yaw;

    public float maxHorizontalRotation = 2f;
    public float maxVerticalRotation = 2f;
    public float smoothness = 0.5f;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Update()
    {
        transform.Translate(Vector3.forward * FlySpeed * Time.deltaTime);


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


        //Yaw, Pitch, Roll
        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 25, Mathf.Abs(verticalInput)) * -Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        float verticalRotation = pitch * maxVerticalRotation;
        float horizontalRotation = roll * maxHorizontalRotation;

        //Apply Rotation
        if (joystick.myOnDrag == true)
        {
            Quaternion newquoto = Quaternion.Euler((Vector3.right * verticalRotation) +
                                                (Vector3.up * Yaw) +
                                                (Vector3.forward * horizontalRotation));

            transform.rotation = Quaternion.Lerp(transform.rotation,
                                                newquoto,
                                                Time.deltaTime * smoothness);
        }
    }

}
