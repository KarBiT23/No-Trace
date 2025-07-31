using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Animator animator;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 moveDirection;

    private bool isShooting = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 move = (forward * vertical + right * horizontal).normalized;

        // Hareket hýzý her zaman sabit
        float currentSpeed = moveSpeed;

        if (move.magnitude >= 0.1f)
        {
            moveDirection = move * currentSpeed;
            controller.Move(moveDirection * Time.deltaTime);

            // Yönü deðiþtir
            transform.forward = move;
        }

        // Animator'a hareket verisi gönder
        animator.SetFloat("Speed", move.magnitude);

        // Ateþ etme kontrolü
        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
            animator.SetBool("IsShooting", isShooting);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
            animator.SetBool("IsShooting", isShooting);
        }

        // Eðer koþarken ateþ etme animasyonu ayrý bir animasyon ise ve Animator'da 'ShootWhileRunning' adýnda özel bir animasyon varsa:
        
        if (isShooting && move.magnitude > 0.1f)
        {
            animator.Play("ShootWhileRunning");
        }
        
    }

    // Animator Event ile çaðrýlýr (animasyon bitince otomatik olarak durdurmak için)
    public void OnShootAnimationEnd()
    {
        isShooting = false;
        animator.SetBool("IsShooting", isShooting);
    }
}
