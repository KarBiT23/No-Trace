using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform cameraTransform;
    public Animator animator;

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        if (animator != null)
            animator.SetBool("isAiming", true); // Oyuna girerken aim animasyonu
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Kamera yönlerini al
        Vector3 forward = cameraTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0f;
        right.Normalize();

        // Hareket yönü
        Vector3 move = (forward * vertical + right * horizontal).normalized;

        // Hareket varsa uygula
        if (move.magnitude >= 0.1f)
        {
            moveDirection = move * moveSpeed;
            controller.Move(moveDirection * Time.deltaTime);

            if (animator != null)
                animator.SetFloat("Speed", move.magnitude);
        }
        else
        {
            if (animator != null)
                animator.SetFloat("Speed", 0f);
        }
    }
}
