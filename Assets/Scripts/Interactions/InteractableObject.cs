using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum InteractType
    {
        Nothing,
        Info,
        Pickup,
        Dialogue,
        Signs,
    }

    public InteractType interactType;
    GameManager _gameManager;

    [Header("Information")]
    public string infoMessage;
    public float delayTime;
    public GameObject infoUI;
    [SerializeField] TMP_Text infoText;

    [Header("Dialogue Settings")]
    public TMP_Text infoDialogue;
    public Dialogue dialogue;


    public void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        infoUI = GameObject.Find("InfoUI");

        infoText = GameObject.Find("InfoText").GetComponent<TMP_Text>();

        infoText.text = null;
    }

    public void Nothing()
    {
        StartCoroutine(ShowInfo(infoMessage, delayTime));
    }

    public void Info()
    {
        StartCoroutine(ShowInfo(infoMessage, delayTime));
    }

    public void Pickup()
    {
        StartCoroutine(ShowInfo(infoMessage, delayTime));
    }

    public void Dialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);

        infoText.text = null;

        if (interactType == InteractType.Pickup)
            this.gameObject.SetActive(false);
    }
}
