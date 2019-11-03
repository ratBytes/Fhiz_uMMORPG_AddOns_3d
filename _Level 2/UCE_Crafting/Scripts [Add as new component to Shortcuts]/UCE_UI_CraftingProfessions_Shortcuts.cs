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

public partial class UCE_UI_CraftingProfessions_Shortcuts : MonoBehaviour
{
    public Button CraftingProfessionsButton;
    public GameObject CraftingProfessionsPanel;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    public void Update()
    {
        CraftingProfessionsButton.onClick.SetListener(() =>
        {
            CraftingProfessionsPanel.SetActive(!CraftingProfessionsPanel.activeSelf);
        });
    }

    // -----------------------------------------------------------------------------------
}