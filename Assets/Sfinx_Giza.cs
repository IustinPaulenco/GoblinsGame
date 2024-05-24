using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sfinx_Giza : MonoBehaviour
{
    public bool playerInRange;

    public bool isShowingInfo;

    public string ItemName = "Sfinxul din Giza";

    public void showInfo()
    {
        isShowingInfo = true;

        InformationSystem.Instance.OpenDialogUI();
        InformationSystem.Instance.infoText.text = "Marele Sfinx de la Giza este o statuie gigantică din calcar, înfățisând un leu cu cap de om. Statuia face parte din ansamblul monumentelor de pe platoul Giza, fiind situată la vest de fluviul Nil. Chipul sfinxului este considerat a-l reprezenta pe faraonul Khafra.";


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
