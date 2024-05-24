using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_Info_UI;
    private Text interaction_text;

    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<Text>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Reset UI elements
        interaction_text.text = "";
        interaction_Info_UI.SetActive(false);

        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            NPC npc = selectionTransform.GetComponent<NPC>();
            NPC_Vanzator npc_vanzator = selectionTransform.GetComponent<NPC_Vanzator>();
            NPC_Primar npc_primar = selectionTransform.GetComponent<NPC_Primar>();
            NPC_Barbat1 npc_barbat1 = selectionTransform.GetComponent<NPC_Barbat1>();
            NPC_Barbat2 npc_barbat2 = selectionTransform.GetComponent<NPC_Barbat2>();
            NPC_Femeie1 npc_femeie1 = selectionTransform.GetComponent<NPC_Femeie1>();
            NPC_Femeie2 npc_femeie2 = selectionTransform.GetComponent<NPC_Femeie2>();
            Piramida_Keops piramida_Keops = selectionTransform.GetComponent<Piramida_Keops>();
            Piramida_Djoser piramida_Djoser = selectionTransform.GetComponent<Piramida_Djoser>();
            Sfinx_Giza sfinx_giza = selectionTransform.GetComponent<Sfinx_Giza>();
            Sit_Amarna sit_amarna = selectionTransform.GetComponent<Sit_Amarna>();
            Templu_Luxor templu_luxor = selectionTransform.GetComponent<Templu_Luxor>();
            Nefertiti_Ending nefertiti = selectionTransform.GetComponent<Nefertiti_Ending>();
            if (npc)
            {
                if (npc.playerInRange)
                {
                    interaction_text.text = "Arheologul local";
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && npc.isTalkingWithPlayer == false)
                    {
                        npc.startConversation();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            } else if (npc_vanzator)
            {
                if (npc_vanzator.playerInRange)
                {
                    interaction_text.text = "Vanzatorul de antichitati";
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && npc_vanzator.isTalkingWithPlayer == false)
                    {
                        npc_vanzator.startConversation();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (npc_primar)
            {
                if (npc_primar.playerInRange)
                {
                    interaction_text.text = "Primarul";
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && npc_primar.isTalkingWithPlayer == false)
                    {
                        npc_primar.startConversation();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (npc_barbat1)
            {
                if (npc_barbat1.playerInRange)
                {
                    interaction_text.text = "Localnic";
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && npc_barbat1.isTalkingWithPlayer == false)
                    {
                        npc_barbat1.startConversation();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (npc_barbat2)
            {
                if (npc_barbat2.playerInRange)
                {
                    interaction_text.text = "Localnic";
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && npc_barbat2.isTalkingWithPlayer == false)
                    {
                        npc_barbat2.startConversation();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (npc_femeie1)
            {
                if (npc_femeie1.playerInRange)
                {
                    interaction_text.text = "Localnic";
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && npc_femeie1.isTalkingWithPlayer == false)
                    {
                        npc_femeie1.startConversation();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (npc_femeie2)
            {
                if (npc_femeie2.playerInRange)
                {
                    interaction_text.text = "Localnic";
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && npc_femeie2.isTalkingWithPlayer == false)
                    {
                        npc_femeie2.startConversation();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (piramida_Keops)
            {
                if (piramida_Keops.playerInRange)
                {
                    interaction_text.text = piramida_Keops.ItemName;
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && piramida_Keops.isShowingInfo == false)
                    {
                        piramida_Keops.showInfo();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (piramida_Djoser)
            {
                if (piramida_Djoser.playerInRange)
                {
                    interaction_text.text = piramida_Djoser.ItemName;
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && piramida_Djoser.isShowingInfo == false)
                    {
                        piramida_Djoser.showInfo();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (sfinx_giza)
            {
                if (sfinx_giza.playerInRange)
                {
                    interaction_text.text = sfinx_giza.ItemName;
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && sfinx_giza.isShowingInfo == false)
                    {
                        sfinx_giza.showInfo();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (sit_amarna)
            {
                if (sit_amarna.playerInRange)
                {
                    interaction_text.text = sit_amarna.ItemName;
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && sit_amarna.isShowingInfo == false)
                    {
                        sit_amarna.showInfo();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (templu_luxor)
            {
                if (templu_luxor.playerInRange)
                {
                    interaction_text.text = templu_luxor.ItemName;
                    interaction_Info_UI.SetActive(true);

                    if (Input.GetMouseButton(0) && templu_luxor.isShowingInfo == false)
                    {
                        templu_luxor.showInfo();
                    }

                    if (DialogSystem.Instance.dialogUIActive)
                    {
                        interaction_Info_UI.SetActive(false);
                    }
                }
            }
            else if (nefertiti)
            {
                if (GameManager.Instance.hasSpokenWithSeller)
                {
                    if (nefertiti.playerInRange)
                    {
                        interaction_text.text = "Copia bustului lui Nefertiti";
                        interaction_Info_UI.SetActive(true);

                        if (Input.GetMouseButton(0) && nefertiti.isShowingEnding == false)
                        {
                            nefertiti.startEnding();
                        }

                        if (Ending_Screen.Instance.endingUIActive)
                        {
                            interaction_Info_UI.SetActive(false);
                        }
                    }
                }
            }
            else
            {
                InteractableObject interactable = selectionTransform.GetComponent<InteractableObject>();
                if (interactable)
                {
                    interaction_text.text = interactable.GetItemName();
                    interaction_Info_UI.SetActive(true);
                }
            }
        }
    }
}
