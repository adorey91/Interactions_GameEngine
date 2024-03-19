using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum InteractType
    {
        Nothing,
        Info,
        Pickup,
        Dialogue,
    }

    public InteractType interactType;

    [Header("Information")]
    public string defaultMessage;
    public string infoMessage;
    public float delayTime;

    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text infoText;
    
    [SerializeField] PlayerController player;
    private Queue<string> dialogue;

    public void Awake()
    {
        if(panel  == null)
        {
            panel = GameObject.FindGameObjectWithTag("ThoughtPanel");
            infoText = panel.GetComponentInChildren<TMP_Text>();
        }
        infoText.text = defaultMessage;
        dialogue = new Queue<string>();
    }

    public void Nothing()
    {
        StartCoroutine(ShowInfo(infoMessage, delayTime, defaultMessage));
    }

    public void Info()
    {
        StartCoroutine(ShowInfo(infoMessage, delayTime, defaultMessage));
    }

    public void Pickup()
    {
        StartCoroutine(ShowInfo(infoMessage, delayTime, defaultMessage));
        Debug.Log($"{this.name} has been picked up");
    }

    public void Dialogue()
    {
        dialogue.Clear();
        HoldPlayer();

    }

    void StartDialogue(string[]  message)
    {

    }

    void HoldPlayer()
    {

    }

    IEnumerator ShowInfo(string message, float delay, string startMessage)
    {
        if (panel != null)
            panel.SetActive(true);
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        if (interactType == InteractType.Pickup)
            this.gameObject.SetActive(false);
        infoText.text = startMessage;
        if (panel != null)
            panel.SetActive(false);
    }
}
