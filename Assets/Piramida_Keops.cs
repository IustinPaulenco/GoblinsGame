using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Piramida_Keops : MonoBehaviour
{
    public bool playerInRange;

    public bool isShowingInfo;

    public string ItemName = "Piramida lui Keops";

    public void showInfo()
    {
        isShowingInfo = true;

        InformationSystem.Instance.OpenDialogUI();
        InformationSystem.Instance.infoText.text = "Marea Piramidă din Gizeh(numita si Piramida lui Keops) a fost cea mai înaltă construcție din lume mai mult de 43 de secole, până în secolul al XIX-lea în 1889 când a fost construit Turnul Eiffel. Avea, la început, 146 m (azi 138 m) înălțime, latura de 227 m și cuprinde 2.521.000 m cubi de piatră.";


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
