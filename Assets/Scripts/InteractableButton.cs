using UnityEngine;

public class InteractableButton : MonoBehaviour, IInteractable
{
    private CountdownTimer countdownTimer;  // Variable para almacenar la referencia al CountdownTimer

    void Start()
    {
        // Buscamos el script CountdownTimer en la escena
        countdownTimer = FindAnyObjectByType<CountdownTimer>();

        // Verificamos si encontramos el CountdownTimer
        if (countdownTimer == null)
        {
            Debug.LogError("No se encontró un CountdownTimer en la escena.");
        }
    }

    public void Interact()
    {
        // Acción a realizar cuando el jugador interactúe con el botón
        Debug.Log("Botón presionado");

        // Llamamos al método StartTimer() de CountdownTimer
        if (countdownTimer != null)
        {
            countdownTimer.StartTimer();  // Inicia el temporizador
        }
    }
}
