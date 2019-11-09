// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// =======================================================================================
using UnityEngine;
using Mirror;
using System;
using System.Linq;
using System.Collections;

// =======================================================================================
// ENTITY
// =======================================================================================
public partial class Entity {

    public UCE_IconOverlay iconOverlay;

    // iconOverlay.Show(0);

    // -----------------------------------------------------------------------------------
    // OnClientAggro_UCE_AggroOverlay
    // -----------------------------------------------------------------------------------
    /*
    [ClientCallback]
    [DevExtMethods("OnClientAggro")]
    private void OnClientAggro_UCE_IconOverlay(Entity entity)
    {

    	if (iconOverlay == null || 
            !isAlive || 
            !entity.isAlive ||
            agent.destination == startPosition ||
            agent.destination == fleePosition ||
            HealthPercent() < fleeHealthThreshold
            )
            return;

        if ( (target == entity || target == null) && entity is Player)
    		iconOverlay.Show(0);
    }
    */

    // -----------------------------------------------------------------------------------
    // OnDamageDealt_UCE_IconOverlay
    // -----------------------------------------------------------------------------------
    /*
    [ClientCallback]
    [DevExtMethods("OnDamageDealt")]
    private void OnDamageDealt_UCE_IconOverlay(int amount)
    {

        if (iconOverlay == null ||
            !isAlive ||
            lastAggressor == null ||
            (lastAggressor != null && !lastAggressor.isAlive) ||
            agent.destination == startPosition ||
            agent.destination == fleePosition ||
            HealthPercent() < fleeHealthThreshold
            ) 
        return;

        if ( (target == lastAggressor || target == null)  && lastAggressor is Player)
            iconOverlay.Show(0);
    }
    */

    // -----------------------------------------------------------------------------------
    // OnDeath_UCE_IconOverlay
    // -----------------------------------------------------------------------------------
    [ClientCallback]
    [DevExtMethods("OnDeath")]
    private void OnDeath_UCE_IconOverlay()
    {
        if (iconOverlay == null) return;

        iconOverlay.Hide();

    }

    // -----------------------------------------------------------------------------------

}

// =======================================================================================
