// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets our new hotkeys for quests.
public partial class UIQuests : MonoBehaviour
{
    private bool isSetup = false;
    private UCE_UI_SettingsVariables settingsVariables;

    // Grabs our settings variables.
    private void Start()
    {
        if (FindObjectOfType<UCE_UI_SettingsVariables>()) isSetup = true;
        else isSetup = false;

        if (isSetup)
            settingsVariables = FindObjectOfType<UCE_UI_SettingsVariables>().GetComponent<UCE_UI_SettingsVariables>();
    }

    // Set our hotkey based on the players selection.
    private void FixedUpdate()
    {
        if (isSetup)
            if (settingsVariables != null)
                if (settingsVariables.keybindUpdate[20])
                {
                    hotKey = settingsVariables.keybindings[20];
                    settingsVariables.keybindUpdate[20] = false;
                }
    }
}