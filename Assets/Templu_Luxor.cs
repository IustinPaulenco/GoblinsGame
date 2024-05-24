using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Templu_Luxor : MonoBehaviour
{
    public bool playerInRange;

    public bool isShowingInfo;

    public string ItemName = "Templul Luxor";

    public void showInfo()
    {
        isShowingInfo = true;

        InformationSystem.Instance.OpenDialogUI();
        InformationSystem.Instance.infoText.text = "Templul din Luxor a fost clădit din material de construcție refolosit (spolia). Templul inițal capela a fost ridicată în timpul domniei faraonului Amenhotep III din dinastia a XVIII-a. Faraonul Amenophis III lasă să se clădească în timpul lui sanctuarul situat în partea sudică a templului, sala de coloane urmând să fie construită în timpul domniei faraonului Amenophis IV, când s-a renunțat la cultul lui Amon";


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
