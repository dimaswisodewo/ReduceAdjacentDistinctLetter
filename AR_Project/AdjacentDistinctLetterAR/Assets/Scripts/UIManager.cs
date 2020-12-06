using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject guidePanel;
    public GameObject loadingPanel;
    public GameObject backButton;
    public GameObject nextProcessButton;
    public Text stepText;

    private void Awake()
    {
        if (instance == null && instance != this)
        {
            instance = this;
        }

        backButton.SetActive(false);
        guidePanel.SetActive(false);
    }

    public IEnumerator SetActiveLoadingPanelCoroutine(bool setActive)
    {
        SetActiveLoadingPanel(setActive);
        yield return null;
    }

    public IEnumerator SetStepTextCoroutine(string inputString)
    {
        SetStepText(inputString);
        yield return null;
    }

    public IEnumerator TrackingFoundCoroutine(bool isFound)
    {
        TrackingFound(isFound);
        yield return null;
    }

    public void TrackingFound(bool isFound)
    {
        if (isFound)
        {
            guidePanel.SetActive(false);
            nextProcessButton.SetActive(true);
            return;
        }

        guidePanel.SetActive(true);
        nextProcessButton.SetActive(false);
    }

    private void SetActiveLoadingPanel(bool setActive)
    {
        loadingPanel.SetActive(setActive);
    }

    private void SetStepText(string inputString)
    {
        stepText.text = inputString;
    }
}
