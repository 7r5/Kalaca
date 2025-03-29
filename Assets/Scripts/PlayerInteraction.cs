using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f;  // Distancia a la que el jugador puede interactuar con los objetos
    public KeyCode interactionKey = KeyCode.E; // Tecla para interactuar con los objetos
    public Material outlineMaterial; // Material del contorno
    private Material originalMaterial; // El material original del objeto
    private Renderer objectRenderer; // El renderer del objeto interactuable

    private void Update()
    {
        // Comprobar si el jugador presiona la tecla de interacción y si hay un objeto cerca
        if (Input.GetKeyDown(interactionKey))
        {
            InteractWithObject();
        }

        // Detectar si el jugador está cerca de un objeto interactuable para iluminarlo
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
        {
            IInteractable interactableObject = hit.collider.GetComponent<IInteractable>();

            if (interactableObject != null)
            {
                // Resaltar el objeto si tiene un renderer
                objectRenderer = hit.collider.GetComponent<Renderer>();
                if (objectRenderer != null)
                {
                    // Guardar el material original y cambiar al material de contorno
                    if (originalMaterial == null)
                    {
                        originalMaterial = objectRenderer.material;
                    }
                    objectRenderer.material = outlineMaterial;
                }
            }
        }
        else
        {
            // Si el jugador ya no está cerca, restaurar el material original
            if (objectRenderer != null)
            {
                objectRenderer.material = originalMaterial;
            }
        }
    }

    private void InteractWithObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
        {
            IInteractable interactableObject = hit.collider.GetComponent<IInteractable>();

            if (interactableObject != null)
            {
                interactableObject.Interact();
            }
        }
    }
}
