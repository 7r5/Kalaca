using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilidad del mouse
    public Transform playerBody; // Asignar manualmente el objeto del jugador en el Inspector
    public Vector3 cameraOffset = new Vector3(0, 1.5f, 0); // Ajuste para centrar la c�mara

    private float xRotation = 0f; // Control de la rotaci�n vertical

    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

        // Centrar la c�mara al jugador al inicio
        if (playerBody != null)
        {
            transform.position = playerBody.position + cameraOffset;
        }
        else
        {
            Debug.LogError("El objeto 'playerBody' no est� asignado. Aseg�rate de asignarlo en el Inspector.");
        }
    }

    void Update()
    {
        // Entrada del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotaci�n vertical
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotaci�n vertical

        // Aplicar rotaci�n vertical a la c�mara
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Aplicar rotaci�n horizontal al cuerpo del jugador
        playerBody.Rotate(Vector3.up * mouseX);

        // Mantener la c�mara centrada en el jugador
        transform.position = playerBody.position + cameraOffset;
    }
}