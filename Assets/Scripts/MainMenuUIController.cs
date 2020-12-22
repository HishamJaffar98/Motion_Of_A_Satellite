using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] Animator headingAnimator;

    public void SetAnimatorParameter(string animatorName,string parameterName,bool value)
    {
        if(animatorName == "HeadingAnimator")
        {
            headingAnimator.SetTrigger(parameterName);
        }
    }
}
