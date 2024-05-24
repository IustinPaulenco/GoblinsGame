using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Piramida_Djoser : MonoBehaviour
{
    public bool playerInRange;

    public bool isShowingInfo;

    public string ItemName = "Piramida lui Djoser";

    public void showInfo()
    {
        isShowingInfo = true;

        InformationSystem.Instance.OpenDialogUI();
        InformationSystem.Instance.infoText.text = "Piramida în Trepte a lui Djoser de la Saqqara este opera arhitectului Imhotep si este considerata ca fiind cea mai veche piramida din Egipt, construida acum aproximativ 4700 de ani.Construcția de 118 ori 140 de metri , cu 6 niveluri și o înălțime de 60 de metri , pare a fi monumentul funerar al faraonului Djoser.";


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
