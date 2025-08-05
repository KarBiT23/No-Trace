using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Fare hassasiyeti
    public Transform playerBody;
    public float smoothTime = 0.05f; // Yumuþatma süresi

    float xRotation = 0f;
    float currentMouseX, currentMouseY;
    float mouseXVelocity, mouseYVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Fare inputlarýný al
        float targetMouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float targetMouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Yumuþatma (SmoothDamp)
        currentMouseX = Mathf.SmoothDamp(currentMouseX, targetMouseX, ref mouseXVelocity, smoothTime);
        currentMouseY = Mathf.SmoothDamp(currentMouseY, targetMouseY, ref mouseYVelocity, smoothTime);

        // Yukarý-aþaðý bakýþ (X ekseni)
        xRotation -= currentMouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f); // Ýnsan boynu gibi sýnýr

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Saða-sola dönme (Y ekseni)
        playerBody.Rotate(Vector3.up * currentMouseX);
    }
}
