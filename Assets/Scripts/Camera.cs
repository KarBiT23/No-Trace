using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Fare hassasiyeti
    public Transform playerBody;
    public float smoothTime = 0.05f; // Yumu�atma s�resi

    float xRotation = 0f;
    float currentMouseX, currentMouseY;
    float mouseXVelocity, mouseYVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Fare inputlar�n� al
        float targetMouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float targetMouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Yumu�atma (SmoothDamp)
        currentMouseX = Mathf.SmoothDamp(currentMouseX, targetMouseX, ref mouseXVelocity, smoothTime);
        currentMouseY = Mathf.SmoothDamp(currentMouseY, targetMouseY, ref mouseYVelocity, smoothTime);

        // Yukar�-a�a�� bak�� (X ekseni)
        xRotation -= currentMouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f); // �nsan boynu gibi s�n�r

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Sa�a-sola d�nme (Y ekseni)
        playerBody.Rotate(Vector3.up * currentMouseX);
    }
}
