using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float angleXLimit;
    [SerializeField] private float angleYLimit;
    [SerializeField] public float rotationSpeed = 1;

    private float lookX;
    private float lookY;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void OnLook(InputValue lookValue)
    {
        Vector2 lookVector = lookValue.Get<Vector2>();

        lookX = lookVector.x;
        lookY = lookVector.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // X rotation limit
        xRotation -= lookY * rotationSpeed;
        xRotation = Mathf.Clamp(xRotation, -angleXLimit, angleXLimit);

        // Y rotation limit
        yRotation += lookX * rotationSpeed;
        yRotation = Mathf.Clamp(yRotation, -angleYLimit, angleYLimit);


        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        //cameraTransform.Rotate(Vector3.up * yRotation);
    }
}
