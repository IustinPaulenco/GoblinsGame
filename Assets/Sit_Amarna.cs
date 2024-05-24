using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sit_Amarna : MonoBehaviour
{
    public bool playerInRange;

    public bool isShowingInfo;

    public string ItemName = "Amarna(Situl arhelogic)";

    public void showInfo()
    {
        isShowingInfo = true;

        InformationSystem.Instance.OpenDialogUI();
        InformationSystem.Instance.infoText.text = "Amarna este un vast sit arheologic egiptean, care reprezintă rămășițele capitalei nou înființate și construite de faraonul Akhenaton de la sfârșitul dinastiei a optsprezecea, și abandonat la scurt timp după decesul său. Numele orașului folosit de egiptenii antici este scris ca Akhetaten.";


        InformationSystem.Instance.option1BTN.onClick.RemoveAllListeners();


        InformationSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Inchide";
        InformationSystem.Instance.option1BTN.onClick.AddListener(() =>
        {
            InformationSystem.Instance.CloseDialogUI();
            isShowingInfo = false;
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
