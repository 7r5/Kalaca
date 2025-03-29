using UnityEngine;
using UnityEngine.UI;  // Para UI estándar
using TMPro;  // Si usas TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60f;  // Tiempo inicial en segundos (1 minuto)
    public Text timerText;  // Para UI estándar (Text)
    // public TMP_Text timerText;  // Si usas TextMeshPro en vez de UI estándar
    private GameOverManager gameOverManager;  // Referencia al GameOverManager
    private bool isTimeRunning = false;  // Indicador de si el temporizador está en marcha

    void Start()
    {
        // TODO: add suppport to avoid manual object selection:
        // gameOverManager = player.GetComponent<GameOverManager>();
    }

    void Update()
    {
        if (isTimeRunning)
        {
            timeRemaining -= Time.deltaTime;  // Restamos el tiempo cada frame

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                EndGame();  // Finalizamos el juego cuando el tiempo se agote
            }

            // Actualizamos el texto del temporizador
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        // Calculamos minutos y segundos
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Actualizamos el texto para mostrar el tiempo restante en formato mm:ss
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        // Detenemos el temporizador
        isTimeRunning = false;

        // Llamamos al método del GameOverManager para mostrar el panel y deshabilitar los controles
        gameOverManager = FindAnyObjectByType<GameOverManager>();

        if (gameOverManager != null)
        {
            gameOverManager.TriggerGameOver();  // Inicia el Game Over
        }
    }

    public void StartTimer()
    {
        isTimeRunning = true;
    }
}
