using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpPrefab;
    public GameObject canvasObject;
    public string description;

    public void start()
    {
        CreatePopUp(description);
    }

    public void CreatePopUp(string description)
    {
        GameObject createdPopUpObject = Instantiate(popUpPrefab, canvasObject.transform);
        createdPopUpObject.GetComponent<PopUp>().SetPopUpDescription(description);
        MovePopUp(createdPopUpObject);

    }

    public void MovePopUp(GameObject createdPopUpObject)
    {
        RectTransform rectTransform = createdPopUpObject.GetComponent<RectTransform>();
        rectTransform.DOAnchorPosY(-100, 3f).OnComplete(() => DestroyPopUp(createdPopUpObject));
    }

    private void DestroyPopUp(GameObject popUpObject)
    {
        Destroy(popUpObject);
    }

}
