using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_Barbat1 : MonoBehaviour
{
    public bool playerInRange;

    public bool isTalkingWithPlayer;

    public Animator animator;
    PopUpManager popUpManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        popUpManager = FindObjectOfType<PopUpManager>();
    }

    public void startConversation()
    {
        isTalkingWithPlayer = true;
        print("Conversation started");

        animator.SetBool("isTalking", true);

        DialogSystem.Instance.OpenDialogUI();
        DialogSystem.Instance.dialogText.text = "Salut! Te ajut cu ceva?";

        // Clear previous listeners
        DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
        DialogSystem.Instance.option2BTN.onClick.RemoveAllListeners();

        // Set up the first layer of the conversation
        DialogSystem.Instance.option2BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Nu, multumesc!";
        DialogSystem.Instance.option2BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.CloseDialogUI();
            isTalkingWithPlayer = false;

            animator.SetBool("isTalking", false);
        });

        DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Cunosti ceva mituri locale?";
        DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.dialogText.text = "Din ce am auzit, sunt cateva obiecte care lipsesc din sit-ul local, dar ce stiu eu..";
            DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Am inteles, va multumesc!";
            DialogSystem.Instance.option2BTN.interactable = false;

            // Clear previous listeners and add the final response listener
            DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
            DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
            {
                DialogSystem.Instance.CloseDialogUI();
                isTalkingWithPlayer = false;

                animator.SetBool("isTalking", false);

                // Reset button interactable state
                DialogSystem.Instance.option2BTN.interactable = true;

                popUpManager.CreatePopUp("Incearca sa discuti cu arheologul local");
            });
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
