using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainSceneUIController : MonoBehaviour
{
    [SerializeField] Slider velocitySlider;
    [SerializeField] TextMeshProUGUI velocityText;
    [SerializeField] TextMeshProUGUI specialText;
    [SerializeField] GameObject launchButton;
    [SerializeField] GameObject explanationButton;
    AudioSource narrator;

    Color semiTransparent = new Color(1f, 1f, 1f, 0.2f);
    Color opaque = new Color(1f, 1f, 1f, 1f);
    void Start()
    {
        narrator = GameObject.FindGameObjectWithTag("Narrator").GetComponent<AudioSource>();
    }

    void Update()
    {
        float newValue = (Mathf.Round(velocitySlider.value * 10))/10;
        velocityText.text = newValue.ToString() + " km/s";
        if (newValue < 7.8f)
        {
            specialText.text = "";
        }
        else if (newValue >= 7.8f && newValue < 11.2f)
        {
            specialText.text = "Escape Velocity";
        }
        else if (newValue >= 11.2f)
        {
            specialText.text = "Orbital Velocity";
        }
    }

    public void ChangeUIObjectColor(string objectName,bool toggleValue)
    {
        if(objectName=="LaunchButton" && toggleValue==true)
        {
            launchButton.GetComponent<Image>().color = semiTransparent;
            launchButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        else if(objectName == "LaunchButton" && toggleValue == false)
        {
            launchButton.GetComponent<Image>().color = opaque;
            launchButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if(objectName == "ExplanationButton" && toggleValue == true)
        {
            explanationButton.GetComponent<Image>().color = semiTransparent;
            explanationButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        else if(objectName == "ExplanationButton" && toggleValue == false)
        {
            explanationButton.GetComponent<Image>().color = opaque;
            explanationButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        }
    }

    public void ChangeText(string objectName,bool toggleValue)
    {
        if (objectName == "LaunchText" && toggleValue == true)
        {
            launchButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Reset";
        }
        else if(objectName == "LaunchText" && toggleValue == false)
        {
            launchButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Launch";
        }
    }

    public void ToggleObjectInteractivity(string objectName,bool toggleValue)
    {
        if (objectName == "VelocitySlider" && toggleValue == true)
        {
            velocitySlider.interactable = true;
        }
        else if(objectName == "VelocitySlider" && toggleValue == false)
        {
            velocitySlider.interactable = false;
        }
    }

    public void ToggleNarrator(bool toggleValue)
    {
        if(toggleValue==true)
        {
            narrator.Play();
        }
        else
        {
            narrator.Stop();
        }
    }

    public float SliderValue()
    {
        return (Mathf.Round(velocitySlider.value*10))/10;
    }
}
