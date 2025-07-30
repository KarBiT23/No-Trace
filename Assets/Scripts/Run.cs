using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    public Animator animator;

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Hareket vekt�r�
        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;

        // Shift'e bas�l�ysa ko�ma modu
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float speed = isRunning ? runSpeed : walkSpeed;

        // Hareket ettir
        if (move.magnitude >= 0.1f)
        {
            moveDirection = move * speed;
            controller.Move(moveDirection * Time.deltaTime);
        }

        // Animator parametreleri
        animator.SetFloat("Speed", move.magnitude * (isRunning ? 2f : 1f)); // Ko�ma daha b�y�k de�er verir
        //animator.SetBool("isRunning", isRunning);
    }
}
