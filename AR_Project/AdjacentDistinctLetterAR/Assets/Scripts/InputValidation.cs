using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputValidation : MonoBehaviour
{
    public static InputValidation instance;
    public InputField inputField;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void InputStringValidation()
    {
        char[] tempChar = inputField.text.ToLower().ToCharArray();
        for (int i = 0; i < tempChar.Length; i++)
        {
            if (tempChar[i] == 'a' || tempChar[i] == 'b' || tempChar[i] == 'c')
            {
                if (i == tempChar.Length - 1)
                {
                    SceneLoader.instance.validatedInput = inputField.text.ToLower();
                    SceneLoader.instance.LoadScene(SCENE.MAIN);
                }

                continue;
            }

            Debug.Log("Word must only contain a, b, and c!");
            break;
        }
    }
}
