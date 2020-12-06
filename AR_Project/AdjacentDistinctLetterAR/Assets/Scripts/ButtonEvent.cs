using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public void OnSubmitButtonClicked()
    {
        InputValidation.instance.InputStringValidation();
    }

    public void OnBackButtonClicked()
    {
        SceneLoader.instance.LoadScene(SCENE.MENU);
    }

    public void OnStartButtonClicked()
    {
        StartCoroutine(ObjectManager.instance.ButtonEventCoroutine());
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
