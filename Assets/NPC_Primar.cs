using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_Primar : MonoBehaviour
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

        if (GameManager.Instance.hasSpokenWithSeller)
        {
          
            DialogSystem.Instance.dialogText.text = "Ah, vad ca ai vorbit deja cu vanzatorul. Da, acei cercetatori au luat bustul.";
        }
        else
        {
            
            DialogSystem.Instance.dialogText.text = "Buna ziua stimate domn! Ce va aduce in aceste zone?";
        }

       
        DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
        DialogSystem.Instance.option2BTN.onClick.RemoveAllListeners();

       
        DialogSystem.Instance.option2BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Nimic";
        DialogSystem.Instance.option2BTN.onClick.AddListener(() =>
        {
            DialogSystem.Instance.CloseDialogUI();
            isTalkingWithPlayer = false;
            animator.SetBool("isTalking", false);
        });

        if (GameManager.Instance.hasSpokenWithSeller)
        {
            DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "De ce au facut asta?";
        }
        else
        {
            DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Misterul Bustului lui Nefertiti";
        }
            
        DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
        {
            if (GameManager.Instance.hasSpokenWithSeller)
            {
                DialogSystem.Instance.dialogText.text = "Se pare ca au incercat sa insele autoritatile locale..poti afla mai multe acum in spatele sit-ului";
                DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Am inteles, va multumesc!";

                popUpManager.CreatePopUp("Se pare ca vei afla mai multe in spatele sitului..");
            }
            else
            {
                DialogSystem.Instance.dialogText.text = "Din pacate acei cercetatori din Germania au facut mai mult decat sa cerceteze zona..";
                DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Am inteles, va multumesc!";

            }

            DialogSystem.Instance.option2BTN.interactable = false;

            // Clear previous listeners and add the final response listener
            DialogSystem.Instance.option1BTN.onClick.RemoveAllListeners();
            DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
            {
                DialogSystem.Instance.CloseDialogUI();
                isTalkingWithPlayer = false;
                animator.SetBool("isTalking", false);


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
