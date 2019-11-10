// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Mirror;

// SKILL

public partial struct Skill
{

    // -------------------------------------------------------------------------
    // UCE_CheckSkillConditions
    // -------------------------------------------------------------------------
    public bool UCE_CheckSkillConditions(Entity caster)
    {
        bool bValid = false;

        bValid = UnityEngine.Random.value <= data.skillConditions.activationChance;

        return bValid;
    }

}