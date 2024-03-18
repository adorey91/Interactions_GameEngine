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
    [SerializeField] TextMeshProUGUI information;
    [SerializeField] TMP_Text infoText;
    public string infoMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Nothing()
    {

        Debug.Log("Nothing is happening");
                
    }

    void Info()
    {
        StartCoroutine(ShowInfo(infoMessage, 0.5f));

    }

    void Pickup()
    {

    }

    void Dialogue()
    {

    }

    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;
    }
}
