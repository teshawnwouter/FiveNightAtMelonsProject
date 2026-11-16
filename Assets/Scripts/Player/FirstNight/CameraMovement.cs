using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private Vector2 mousePosition;
    private float rotationSpeed = 50f;
    private float rotationClamp = 45f;
    private float yOffset;
    private Quaternion rotation;

    private void Awake()
    {
        rotation = transform.localRotation;
    }

    private void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();

        float direction  = IsMouseOnLeftSide() ? -1f : IsMouseOnRightSide() ? 1f : 0f;
        yOffset = Mathf.Clamp(yOffset + direction * rotationSpeed * Time.deltaTime, -rotationClamp, rotationClamp);

        transform.localRotation = rotation * Quaternion.Euler(0f, yOffset, 0f);
    }

    private bool IsMouseOnLeftSide()
    {
        return mousePosition.x < Screen.width * 0.1f;
    }

    private bool IsMouseOnRightSide()
    {
        return mousePosition.x > Screen.width * 0.9f;
    }
}
