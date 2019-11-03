// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;
using Mirror;
using System;
using System.Linq;
using System.Collections;

// PLAYER

public partial class Player
{
    // -----------------------------------------------------------------------------------
    // OnSelect_UCE_IndicatorProjector
    // @Client
    // -----------------------------------------------------------------------------------
    [Client]
    [DevExtMethods("OnSelect")]
    private void OnSelect_UCE_IndicatorProjector(Entity entity)
    {
        if (entity != null &&
            entity.GetComponent<UCE_IndicatorProjector>() != null &&
            Utils.ClosestDistance(collider, entity.collider) <= interactionRange &&
            state == "IDLE"
            )
        {
            UCE_IndicatorProjector ip = entity.GetComponent<UCE_IndicatorProjector>();

            ip.Show();
        }
    }

    // -----------------------------------------------------------------------------------
}