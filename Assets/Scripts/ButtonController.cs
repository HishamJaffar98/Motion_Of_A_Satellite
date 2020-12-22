using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    MainMenuUIController mmUIController;
    MainSceneUIController msUIController;
    MotionOfASatellite satellite;
    bool isLaunched = false;
    bool explanationStarted = false;
    void Start()
    {
        mmUIController = FindObjectOfType<MainMenuUIController>();
        msUIController = FindObjectOfType<MainSceneUIController>();
        satellite = FindObjectOfType<MotionOfASatellite>();
    }
    void Update()
    {
        
    }

    public void StartButton()
    {
        mmUIController.SetAnimatorParameter("HeadingAnimator", "headingPan",false);
        StartCoroutine(LevelManager.NextLevel());
    }

    public void QuitButton()
    {
        LevelManager.QuitApplication();
    }

    public void LaunchButton()
    {
        if (!isLaunched)
        {
            SetLaunchPath();
            ToggleLaunchUI(true);
        }
        else
        {
            satellite.ResetPosition();
            ToggleLaunchUI(false);
        }
    }

    private void SetLaunchPath()
    {
        float sliderValue = msUIController.SliderValue();
        satellite.movementSpeed = sliderValue;
        if (sliderValue < 7.8f)
        {
            satellite.followCircle = true;
        }
        else if (sliderValue >= 7.8f && sliderValue < 11.2f)
        {
            satellite.followEllipse = true;
        }
        else if (sliderValue >= 11.2f && sliderValue < 13f)
        {
            satellite.followParabola = true;
        }
        else if (sliderValue > 13f)
        {
            satellite.followHyperbola = true;
        }
    }

    private void ToggleLaunchUI(bool toggleValue)
    {
        isLaunched = toggleValue;
        msUIController.ChangeUIObjectColor("LaunchButton", toggleValue);
        msUIController.ChangeText("LaunchText", toggleValue);
        msUIController.ToggleObjectInteractivity("VelocitySlider", !toggleValue);
    }

    public void BackButton()
    {
        StartCoroutine(LevelManager.PreviousLevel());
    }

    public void ExplanationButton()
    {
        if(!explanationStarted)
        {
            explanationStarted=true;
            msUIController.ChangeUIObjectColor("ExplanationButton", true);
            msUIController.ToggleNarrator(true);
            FindObjectOfType<BGMMusic>().GetComponent<AudioSource>().volume = 0.1f;
        }
        else
        {
            explanationStarted = false;
            msUIController.ChangeUIObjectColor("ExplanationButton", false);
            msUIController.ToggleNarrator(false);
            FindObjectOfType<BGMMusic>().GetComponent<AudioSource>().volume = 0.4f;
        }
        
    }
}
