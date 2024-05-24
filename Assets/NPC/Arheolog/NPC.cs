using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
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

        // Start talking animation
        animator.SetBool("isTalking", true);

        DialogSystem.Instance.OpenDialogUI();
        DialogSystem.Instance.dialogText.text = "Buna! Te pot ajuta cu ceva?";

        // Clear previous listeners
        DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
        DialogSystem.Instance.option2BTN.onClick.RemoveAllListeners();

        // Set up the first layer of the conversation
        DialogSystem.Instance.option2BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Nu, Multumesc";
        DialogSystem.Instance.option2BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.CloseDialogUI();
            isTalkingWithPlayer = false;

            // Stop talking animation
            animator.SetBool("isTalking", false);
        });

        DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Aveti detalii despre bustul lui Nefertiti?";
        DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.dialogText.text = "Stiu doar ca este unul dintre cele mai pretioase artefacte descoperite aici, este o comoara a acestui sit! Dar cateva persoane au vrut sa aibe doar ei parte de ea..";
            DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Am inteles, va multumesc!";
            DialogSystem.Instance.option2BTN.interactable = false;

            // Clear previous listeners and add the final response listener
            DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
            DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
            {
                DialogSystem.Instance.CloseDialogUI();
                isTalkingWithPlayer = false;

                // Stop talking animation
                animator.SetBool("isTalking", false);

                // Reset button interactable state
                DialogSystem.Instance.option2BTN.interactable = true;

                popUpManager.CreatePopUp("Poate vanzatorul de antichitati stie mai multe.");
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
