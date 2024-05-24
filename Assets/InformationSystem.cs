using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationSystem : MonoBehaviour
{
    public static InformationSystem Instance { get; set; }

    public Text infoText;

    public Button option1BTN;

    public Canvas infoUI;

    public bool infoUIActive;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void OpenDialogUI()
    {
        infoUI.gameObject.SetActive(true);
        infoUIActive = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseDialogUI()
    {
        infoUI.gameObject.SetActive(false);
        infoUIActive = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
