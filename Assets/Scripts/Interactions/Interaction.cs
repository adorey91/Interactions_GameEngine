using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameObject interactable = null;
    [SerializeField] InteractableObject interactableObject = null;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && interactableObject != null)
        {
            CheckInteraction();
        }
    }

    void CheckInteraction()
    {
        if (interactableObject.interactType == InteractableObject.InteractType.Nothing)
            interactableObject.Nothing();
        if(interactableObject.interactType == InteractableObject.InteractType.Pickup)
            interactableObject.Pickup();
        if(interactableObject.interactType == InteractableObject.InteractType.Info)
            interactableObject.Info();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = collision.gameObject;
        interactableObject = interactable.GetComponent<InteractableObject>();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
        interactableObject = null;
    }
}