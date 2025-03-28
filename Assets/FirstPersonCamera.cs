using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilidad del mouse
    public Transform playerBody; // Asignar manualmente el objeto del jugador en el Inspector
    public Vector3 cameraOffset = new Vector3(0, 1.5f, 0); // Ajuste para centrar la cámara

    private float xRotation = 0f; // Control de la rotación vertical

    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

        // Centrar la cámara al jugador al inicio
        if (playerBody != null)
        {
            transform.position = playerBody.position + cameraOffset;
        }
        else
        {
            Debug.LogError("El objeto 'playerBody' no está asignado. Asegúrate de asignarlo en el Inspector.");
        }
    }

    void Update()
    {
        // Entrada del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación vertical
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotación vertical

        // Aplicar rotación vertical a la cámara
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Aplicar rotación horizontal al cuerpo del jugador
        playerBody.Rotate(Vector3.up * mouseX);

        // Mantener la cámara centrada en el jugador
        transform.position = playerBody.position + cameraOffset;
    }
}