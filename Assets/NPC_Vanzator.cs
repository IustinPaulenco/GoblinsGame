using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_Vanzator : MonoBehaviour
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
        DialogSystem.Instance.dialogText.text = "Orice iti doresti, poti gasi la mine!";

        // Clear previous listeners
        DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
        DialogSystem.Instance.option2BTN.onClick.RemoveAllListeners();

        // Set up the first layer of the conversation
        DialogSystem.Instance.option2BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Nu, Multumesc";
        DialogSystem.Instance.option2BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.CloseDialogUI();
            isTalkingWithPlayer = false;
            animator.SetBool("isTalking", false);
        });

        DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Poate bustul lui Nefertiti?";
        DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.dialogText.text = "Ah, aveti gusturi bune! Din pacate l-au luat inainte sa il pot vedea. Poate primarul stie cine a facut-o";
            DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Am inteles, va multumesc!";
            DialogSystem.Instance.option2BTN.interactable = false;

            DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
            DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
            {
                DialogSystem.Instance.CloseDialogUI();
                isTalkingWithPlayer = false;
                animator.SetBool("isTalking", false);


                GameManager.Instance.hasSpokenWithSeller = true;

                popUpManager.CreatePopUp("Poate primarul stie mai multe defapt..");
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
