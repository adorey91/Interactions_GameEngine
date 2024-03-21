using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Timeline.AnimationPlayableAsset;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public GameObject player;
    public Animator animator;

    private Queue<string> dialogueQueue;

    void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        dialogueQueue = new Queue<string>();
        dialogueUI.SetActive(false);    
    }

    public void StartDialogue(string[] dialogue)
    {
        _gameManager.LoadState("Dialogue");
        dialogueQueue.Clear();
        dialogueUI.SetActive(true);

        foreach (string currentLine in dialogue)
        {
            dialogueQueue.Enqueue(currentLine);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string currentLine = dialogueQueue.Dequeue();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = ""; // Clear text before typing

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust the time delay between each letter
        }
    }

    void EndDialogue()
    {
        dialogueQueue.Clear();
        dialogueUI.SetActive(false);

        _gameManager.LoadState("Gameplay");
    }
}
