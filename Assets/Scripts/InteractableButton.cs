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
            Debug.LogError("No se encontr� un CountdownTimer en la escena.");
        }
    }

    public void Interact()
    {
        // Acci�n a realizar cuando el jugador interact�e con el bot�n
        Debug.Log("Bot�n presionado");

        // Llamamos al m�todo StartTimer() de CountdownTimer
        if (countdownTimer != null)
        {
            countdownTimer.StartTimer();  // Inicia el temporizador
        }
    }
}
