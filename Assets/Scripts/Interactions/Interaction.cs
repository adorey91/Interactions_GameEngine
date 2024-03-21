using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameObject interactable = null;
    [SerializeField] InteractableObject interactableObject = null;
    [SerializeField] GameObject canInteract;

    private void Start()
    {
        canInteract.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && interactableObject != null)
            CheckInteraction();
    }

    void CheckInteraction()
    {
        if (interactableObject.interactType == InteractableObject.InteractType.Nothing)
            interactableObject.Nothing();
        else if (interactableObject.interactType == InteractableObject.InteractType.Pickup)
            interactableObject.Pickup();
        else if (interactableObject.interactType == InteractableObject.InteractType.Info)
            interactableObject.Info();
        else if (interactableObject.interactType == InteractableObject.InteractType.Dialogue)
            interactableObject.Dialogue();
        else if (interactableObject.interactType == InteractableObject.InteractType.Signs)
            interactableObject.Signs();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = collision.gameObject;
        interactableObject = interactable.GetComponent<InteractableObject>();
        if (interactableObject != null)
            canInteract.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        canInteract.SetActive(false);
        interactable = null;
        interactableObject = null;
    }
}