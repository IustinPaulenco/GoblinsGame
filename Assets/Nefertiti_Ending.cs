using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nefertiti_Ending : MonoBehaviour
{
    public bool playerInRange;

    public bool isShowingEnding;

    private PlayerMovement playerMovement;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
        }
    }

    public void startEnding()
    {
        if (playerMovement != null)
        {
            playerMovement.canMove = false;
        }

        isShowingEnding = true;

       Ending_Screen.Instance.OpenEndingUI();
       Ending_Screen.Instance.option1BTN.onClick.RemoveAllListeners();
        DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.CloseDialogUI();
            isShowingEnding = false;
            Application.Quit();

        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #endif
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
