using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_Barbat2 : MonoBehaviour
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
        DialogSystem.Instance.dialogText.text = "Salut! Alt cercetator, nu?";

 
        DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
        DialogSystem.Instance.option2BTN.onClick.RemoveAllListeners();

  
        DialogSystem.Instance.option2BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Nu, doar sa vizitez zona";
        DialogSystem.Instance.option2BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.CloseDialogUI();
            isTalkingWithPlayer = false;

            animator.SetBool("isTalking", false);
        });

        DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Nu, doar vizitez..au fost multi cercetatori in ultima vreme?";
        DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.dialogText.text = "Din ce in ce mai multi pe zi ce trece, jur ca nu inteleg de ce sunt asa interesati..";
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
