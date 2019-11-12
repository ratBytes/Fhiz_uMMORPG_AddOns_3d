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
// MONSTER
// =======================================================================================
public partial class Monster {

    // -----------------------------------------------------------------------------------
    // OnDamageDealt_UCE_Morale
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnDamageDealt")]
    private void OnDamageDealt_UCE_Morale(int amount)
    {
        morale -= amount;
    }





    // -----------------------------------------------------------------------------------

}

// =======================================================================================
