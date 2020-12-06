using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public TextMesh displayText;

    public void SetDisplayText(string inputText)
    {
        displayText.text = inputText;
    }
}

