using UnityEngine;

/// <summary>
/// 
/// </summary>

[RequireComponent(typeof(Rigidbody), typeof (CapsuleCollider))]
public class PlayerPrimeraPersona : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Cam")]
    public Transform cameraTransform;
    public float mouseSensitivity;
    public float maxLookAngle;

    private Rigidbody rb;
    private float verticalLookRotation;

    void Start()
    {
        if (moveSpeed == 0f) moveSpeed = 5f;
        if (jumpForce == 0f) jumpForce = 5f;
        if (mouseSensitivity == 0f) mouseSensitivity = 2f;
        if (maxLookAngle == 0f) maxLookAngle = 80f;

        rb = GetComponent<Rigidbody>();

        cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Rotacion del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotacion del cuerpo
        transform.Rotate(Vector3.up * mouseX);

        // Rotacion vertical de la cámara (limitada)
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -maxLookAngle, maxLookAngle);
        cameraTransform.localEulerAngles = Vector3.right * verticalLookRotation;

        // Salto
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = Vector3.zero;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    void FixedUpdate()
    {
        // Movimiento
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        Vector3 velocity = moveDirection.normalized * moveSpeed;

        // Preservar componente vertical de la velocidad
        velocity.y = rb.linearVelocity.y;

        // Asignar linearVelocity
        rb.linearVelocity = velocity;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.25f);
    }
}
