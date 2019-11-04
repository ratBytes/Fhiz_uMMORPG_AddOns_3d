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
using Mirror;

// LogoutTimer

public partial class Player
{
    [Header("[UCE LOGOUT TIMER]")]
    [Range(1, 9999)] public float logoutWarningTime = 30f;

    [Range(1, 9999)] public float logoutKickTime = 60f;

    protected float _logoutTimer = 0;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    [ClientCallback]
    [DevExtMethods("Update")]
    private void Update_UCE_LogoutTimer()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (player.state == "IDLE")
        {
            _logoutTimer += cacheTimerInterval;
        }
        else
        {
            _logoutTimer = 0;
            UCE_UI_LogoutTimer_Popup.singleton.Hide();
        }

        if (_logoutTimer > logoutKickTime)
            NetworkManagerMMO.Quit();
        else if (_logoutTimer > logoutWarningTime)
            UCE_UI_LogoutTimer_Popup.singleton.Show();
    }

    // -----------------------------------------------------------------------------------
}
