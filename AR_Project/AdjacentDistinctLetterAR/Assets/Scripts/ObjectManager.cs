using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public AdjacentLetter adjacentLetter;
    public GameObject letter;
    public Transform letterParent;
    private Vector3 instantiatePos = new Vector3(0, 0, 0);
    private float letterWidth = 0.2f;
    private int stepIdx = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        StartCoroutine(LoadOnStart());
    }

    private IEnumerator LoadOnStart()
    {
        yield return StartCoroutine(UIManager.instance.SetActiveLoadingPanelCoroutine(true));
        yield return StartCoroutine(adjacentLetter.TryReduceAdjacentLetterCoroutine());

        string tempString = "Original: ";
        foreach (string s in adjacentLetter.step)
        {
            tempString = string.Concat(tempString, s, "\n");
        }

        yield return StartCoroutine(UIManager.instance.SetStepTextCoroutine(tempString));
        yield return StartCoroutine(UIManager.instance.SetActiveLoadingPanelCoroutine(false));
        yield return StartCoroutine(UIManager.instance.TrackingFoundCoroutine(false));
        yield return StartCoroutine(ButtonEventCoroutine());
    }

    public IEnumerator ButtonEventCoroutine()
    {
        // Instantiate letter object and set the text
        if (stepIdx < adjacentLetter.step.Count)
        {
            if (letterParent.childCount > 0)
            {
                // Destroy the active letter object
                for (int i = 0; i < letterParent.childCount; i++)
                {
                    Destroy(letterParent.GetChild(i).gameObject);
                }
            }

            char[] stepNow = adjacentLetter.step[stepIdx].ToCharArray();
            yield return StartCoroutine(InstantiateLetter(stepNow));

            // Move the adjacent and distinct letters up
            if (stepIdx < adjacentLetter.step.Count - 1)
            {
                char[] stepNext = adjacentLetter.step[stepIdx + 1].ToCharArray();
                for (int i = 0; i < stepNext.Length; i++)
                {
                    if (stepNow[i] != stepNext[i])
                    {
                        Transform letter = letterParent.GetChild(i).transform;
                        letter.localPosition = new Vector3(letter.localPosition.x, letter.localPosition.y, letter.localPosition.z + 0.1f);
                        letter = letterParent.GetChild(i + 1).transform;
                        letter.localPosition = new Vector3(letter.localPosition.x, letter.localPosition.y, letter.localPosition.z + 0.1f);
                        break;
                    }
                }
            }
            else
            {
                UIManager.instance.backButton.SetActive(true);
                Debug.Log("Done!");
            }


            stepIdx += 1;
            yield return null;
        }


        instantiatePos.x = 0;
    }

    // Instantiate letter object and set the text
    private IEnumerator InstantiateLetter(char[] letterText)
    {
        foreach (char c in letterText)
        {
            GameObject obj = Instantiate(letter, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0) );
            obj.GetComponent<Letter>().SetDisplayText(c.ToString());
            obj.transform.SetParent(letterParent);
            obj.transform.parent = letterParent.transform;
            obj.transform.localPosition = new Vector3(instantiatePos.x, 0, 0f);
            obj.transform.localRotation = new Quaternion(0, 0, 0, 0);
            instantiatePos.x += letterWidth;
            yield return null;
        }
    }
}
