using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBackground : MonoBehaviour
{
    [Header("RGBA Settings")]
    [SerializeField] private Slider redSlider;
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider blueSlider;
    [SerializeField] private Slider alphaSlider;

    public Camera playerCamera;


    public void Start()
    {
        playerCamera = GetComponent<Camera>();
        redSlider.value = 1;
        greenSlider.value = 1;
        blueSlider.value = 1;
        alphaSlider.value = 1;
    }

    public void Update()
    {
        ColorChange();
    }

    public void ColorChange()
    {
        playerCamera.backgroundColor = new Color(redSlider.value, greenSlider.value, blueSlider.value, alphaSlider.value);
    }
}
