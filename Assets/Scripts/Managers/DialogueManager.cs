using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private GameManager _gameManager;
    [Header("UI")]
    public GameObject dialogueUI;
    public Button UIbutton;
    public TMP_Text dialogueName;
    public TMP_Text dialogueText;
    public TMP_Text dialogueButtonText;
    public float fadeSpeed;
    bool isFaded = true;
    private string endDialogue;
    CanvasGroup canvGroup;

    public void Start()
    {
        canvGroup = dialogueUI.GetComponent<CanvasGroup>();

        _gameManager = FindObjectOfType<GameManager>(gameObject);
        sentences = new Queue<string>();
        dialogueUI.SetActive(false);
    }


    public void StartDialogue(Dialogue dialogue)
    {
        _gameManager.LoadState("Dialogue");
        sentences.Clear();
        dialogueUI.SetActive(true);
        StartCoroutine(FadeObject(canvGroup, canvGroup.alpha, isFaded? 1:0));
        isFaded = !isFaded;


        dialogueName.text = dialogue.name;
        dialogueButtonText.text = dialogue.continueDialogue;
        endDialogue = dialogue.endDialogue;


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (sentences.Count == 1)
            dialogueButtonText.text = endDialogue;

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        StartCoroutine(FadeObject(canvGroup, canvGroup.alpha, isFaded ? 1 : 0));
        isFaded = !isFaded;
        sentences.Clear();
        dialogueUI.SetActive(false);

        _gameManager.LoadState("Gameplay");
    }

    IEnumerator FadeObject(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;

        while(counter < fadeSpeed)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter/fadeSpeed);

            yield return null;
        }
    }
}