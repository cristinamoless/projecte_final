using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Objectiu (Player o CameraTarget)")]
    public Transform target;

    [Header("Rotació amb ratolí")]
    public float mouseSensitivity = 20f;
    public float minYAngle = -20f;
    public float maxYAngle = 60f;

    [Header("Distància (zoom amb rodeta)")]
    public float distance = 5f;
    public float minDistance = 2f;
    public float maxDistance = 10f;
    public float zoomSpeed = 2f;

    [Header("Suavitzat")]
    public float smoothSpeed = 10f;

    [Header("Rotar el personatge amb la càmera")]
    public bool rotateTargetWithCamera = true;
    public float targetRotationSpeed = 10f;

    private float currentX = 0f;
    private float currentY = 20f;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("ThirdPersonCamera necessita un target assignat.");
            enabled = false;
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        RotacioRatoli();
        ZoomRoda();
        MouCamera();
    }

    private void RotacioRatoli()
    {
        currentX += Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    }

    private void ZoomRoda()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    private void MouCamera()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
        Vector3 direction = new Vector3(0f, 0f, -distance);

        Vector3 desiredPosition = target.position + rotation * direction;
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        if (rotateTargetWithCamera)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, currentX, 0f);
            target.rotation = Quaternion.Lerp(
                target.rotation,
                targetRotation,
                targetRotationSpeed * Time.deltaTime
            );
        }

        transform.LookAt(target.position);
    }
}

