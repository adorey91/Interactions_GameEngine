using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public GameObject player;
    public Animator animator;

    private Queue<string> dialogueQueue;

    private int _currentlyVisibleCharacterIndex;
    private Coroutine _typewriterCoroutine;

    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _interpuntuationDelay;

    [Header("Typewriter Settings")]
    [SerializeField] float characterPerSecond = 20;
    [SerializeField] float interpuntuationDelay = 0.5f;

    //Skipping Functionality
    private bool _currentlySkipping;
    private WaitForSeconds _skipDelay;

    [Header("Skip Options")]
    [SerializeField] bool quickSkip;
    [SerializeField][Min(1)] int skipSpeedUp = 5;

    // Event Functionality
    private WaitForSeconds _textboxFullEventDelay;
    [SerializeField][Range(0.1f, 0.5f)] private float sendDoneDelay = 0.25f;

    public static event Action CompleteTextRevealed;
    public static event Action<char> CharacterRevealed;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        dialogueQueue = new Queue<string>();
        dialogueUI.SetActive(false);

        _simpleDelay = new WaitForSeconds(1 / characterPerSecond);
        _interpuntuationDelay = new WaitForSeconds(interpuntuationDelay);

        _skipDelay = new WaitForSeconds(1 / characterPerSecond * skipSpeedUp);
        _textboxFullEventDelay = new WaitForSeconds(sendDoneDelay);
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
        StartTypewriterEffect(currentLine);
    }

    void StartTypewriterEffect(string text)
    {
        dialogueText.text = string.Empty;
        _currentlyVisibleCharacterIndex = 0;

        if (_typewriterCoroutine != null)
            StopCoroutine(_typewriterCoroutine);

        _typewriterCoroutine = StartCoroutine(Typewriter(text));
    }

    private IEnumerator Typewriter(string text)
    {
        while (_currentlyVisibleCharacterIndex < text.Length)
        {
            char character = text[_currentlyVisibleCharacterIndex];
            dialogueText.text += character;

            if (!_currentlySkipping && (character == '?' || character == '.' || character == ',' || character == ':' || character == ';' || character == '!' || character == '-'))
                yield return _interpuntuationDelay;
            else
                yield return _currentlySkipping ? _skipDelay : _simpleDelay;

            CharacterRevealed?.Invoke(character);
            _currentlyVisibleCharacterIndex++;
        }

        CompleteTextRevealed?.Invoke();
    }

    void EndDialogue()
    {
        dialogueQueue.Clear();
        dialogueUI.SetActive(false);

        _gameManager.LoadState("Gameplay");
    }
}