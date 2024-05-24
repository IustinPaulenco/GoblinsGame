using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending_Screen : MonoBehaviour
{
    public static Ending_Screen Instance { get; set; }

    public Canvas endingUI;

    public Button option1BTN;

    public bool endingUIActive;

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

    public void OpenEndingUI()
    {
        endingUI.gameObject.SetActive(true);
        endingUIActive = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseEndingUI()
    {
        endingUI.gameObject.SetActive(false);
        endingUIActive = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
