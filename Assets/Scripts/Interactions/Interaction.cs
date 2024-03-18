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
        if (Input.GetKeyDown(KeyCode.Space) && interactableObject != null)
        {
            CheckInteraction();
        }
    }

    void CheckInteraction()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = collision.gameObject;
        interactableObject = GetComponent<InteractableObject>();
    }
}