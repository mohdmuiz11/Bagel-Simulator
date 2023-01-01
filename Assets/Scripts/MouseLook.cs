using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float angleXLimit;
    [SerializeField] private float angleYLimit;

    private float xRotation = 0f;
    private float yRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // X rotation limit
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -angleXLimit, angleXLimit);

        // Y rotation limit
        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -angleYLimit, angleYLimit);


        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        //cameraTransform.Rotate(Vector3.up * yRotation);
    }
}
