using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    public MonoBehaviour interactableScript;
    private IInteractable interactable;

    private void Awake()
    {
        interactable = interactableScript as IInteractable;
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        interactable?.Interact();
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        interactable?.fiInteract();
    }
}
