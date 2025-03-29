using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;  // Panel de Game Over a mostrar
    public GameObject player;  // El jugador cuya interacción queremos deshabilitar
    private MoveController playerController;  // Referencia al script de control del jugador

    void Start()
    {
        // Obtenemos el componente MoveController 
        playerController = player.GetComponent<MoveController>();

        // Si no se encuentra el PlayerController, mostramos un error
        if (playerController == null)
        {
            Debug.LogError("El jugador no tiene un componente PlayerController.");
        }

        // Aseguramos que el Game Over Panel esté oculto al inicio
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    // Este método es llamado cuando el tiempo se acaba
    public void TriggerGameOver()
    {
        // Mostrar el panel de Game Over
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Desactivar los controles del jugador
        if (playerController != null)
        {
            playerController.enabled = false;  // Desactiva el script que maneja los controles del jugador
        }
    }
}
