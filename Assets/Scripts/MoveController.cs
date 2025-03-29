using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 10.0F;
    public float sprintSpeed = 20.0F; // Velocidad al sprintar
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private float currentSpeed; // Almacenamos la velocidad actual (normal o sprint)

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
        // Si estamos en el suelo, determinamos si se está sprintando
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = sprintSpeed; // Aumentamos la velocidad si se está sprintando
            }
            else
            {
                currentSpeed = speed; // De lo contrario, usamos la velocidad normal
            }

            // Movimiento horizontal
            moveDirection.x = Input.GetAxis("Horizontal") * currentSpeed;
            moveDirection.z = Input.GetAxis("Vertical") * currentSpeed;
            moveDirection = transform.TransformDirection(moveDirection); // Convertimos la dirección a espacio global

            // Salto y gravedad
            moveDirection.y = -0.5f; // Mantener al personaje en el suelo
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed; // Ejecutar salto
            }
        }
        else
        {
            // Mientras está en el aire, mantenemos el momentum horizontal
            moveDirection.x = Input.GetAxis("Horizontal") * currentSpeed;
            moveDirection.z = Input.GetAxis("Vertical") * currentSpeed;

            moveDirection = transform.TransformDirection(moveDirection); // Convertir la dirección a espacio global

            // Aplicar gravedad mientras está en el aire
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Movimiento del personaje
        controller.Move(moveDirection * Time.deltaTime);
    }
}
