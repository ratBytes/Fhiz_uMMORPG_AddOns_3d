// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;
using UnityEngine.UI;

// SHORTCUTS

public partial class UCE_UI_HarvestingProfessions_Shortcuts : MonoBehaviour
{
    public Button HarvestingProfessionsButton;
    public GameObject HarvestingProfessionsPanel;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    public void Update()
    {
        HarvestingProfessionsButton.onClick.SetListener(() =>
        {
            HarvestingProfessionsPanel.SetActive(!HarvestingProfessionsPanel.activeSelf);
        });
    }

    // -----------------------------------------------------------------------------------
}
