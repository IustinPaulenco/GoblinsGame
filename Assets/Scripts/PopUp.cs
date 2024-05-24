using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text popUpDescriptionText;

    public void SetPopUpDescription(string text)
    {
        popUpDescriptionText.text = text;   
    }
}
