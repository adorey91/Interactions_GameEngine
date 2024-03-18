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
    [SerializeField] TMP_Text infoText;
    public string defaultMessage;
    public string infoMessage;
    public GameObject panel;

    public void Awake()
    {
        infoText.text = defaultMessage;
    }

    public void Nothing()
    {
        Debug.Log("Nothing is happening");
        StartCoroutine(ShowInfo(infoMessage, 1f, defaultMessage));
    }

    public void Info()
    {
        float delay = 1f;
        if (panel != null)
        {
            panel.SetActive(true);
            delay = 2f;
        }
        StartCoroutine(ShowInfo(infoMessage, delay, defaultMessage));
    }

    public void Pickup()
    {
        Debug.Log($"{this.name} has been picked up");
        gameObject.SetActive(false);
    }

    public void Dialogue()
    {

    }

    IEnumerator ShowInfo(string message, float delay, string startMessage)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = startMessage;
        if (panel != null)
            panel.SetActive(false);
    }
}
