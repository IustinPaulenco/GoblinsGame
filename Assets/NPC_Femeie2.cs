using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_Femeie2 : MonoBehaviour
{
    public bool playerInRange;

    public bool isTalkingWithPlayer;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void startConversation()
    {
        isTalkingWithPlayer = true;


        animator.SetBool("isTalking", true);

        DialogSystem.Instance.OpenDialogUI();
        DialogSystem.Instance.dialogText.text = "Buna! Te pot ajuta cu ceva?";


        DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
        DialogSystem.Instance.option2BTN.onClick.RemoveAllListeners();


        DialogSystem.Instance.option2BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Nu, multumesc";
        DialogSystem.Instance.option2BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.CloseDialogUI();
            isTalkingWithPlayer = false;

            animator.SetBool("isTalking", false);
        });

        DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Stii cumva ce s-a intamplat cu bustul lui Nefertiti?";
        DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.dialogText.text = "Nu stiu, imi pare rau";
            DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Am inteles, va multumesc!";
            DialogSystem.Instance.option2BTN.interactable = false;

 
            DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
            DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
            {
                DialogSystem.Instance.CloseDialogUI();
                isTalkingWithPlayer = false;

                animator.SetBool("isTalking", false);

                DialogSystem.Instance.option2BTN.interactable = true;
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
