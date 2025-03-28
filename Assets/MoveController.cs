using UnityEngine;
using System.Collections;
using System;

public class MoveController : MonoBehaviour
{
    public float speed = 10.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Awake()
    {
        // Crear y asignar el CharacterController si no existe
        controller = gameObject.GetComponent<CharacterController>();
        if (controller == null)
        {
            controller = gameObject.AddComponent<CharacterController>();
        }
    }

    void Update()
    {
        // Movimiento horizontal (siempre permitido)
        moveDirection.x = Input.GetAxis("Horizontal") * speed;
        moveDirection.z = Input.GetAxis("Vertical") * speed;
        moveDirection = transform.TransformDirection(moveDirection);

        // Salto y gravedad
        if (controller.isGrounded)
        {
            moveDirection.y = -0.5f; // Resetear la velocidad vertical
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime; // Aplicar gravedad mientras está en el aire
        }

        // Movimiento
        controller.Move(moveDirection * Time.deltaTime);
    }
}