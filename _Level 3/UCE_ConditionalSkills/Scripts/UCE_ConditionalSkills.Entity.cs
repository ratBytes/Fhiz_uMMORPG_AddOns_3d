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

// ENTITY

public partial class Entity
{

    protected int lastSkill = -1;

    // -------------------------------------------------------------------------
    // NextSkill
    // -------------------------------------------------------------------------
    protected int NextSkill()
    {

        for (int i = 0; i < skills.Count; ++i)
        {
            int index = (lastSkill + 1 + i) % skills.Count;
            if (CastCheckSelf(skills[index]) && skills[index].UCE_CheckSkillConditions(this))
                return index;

        }
        return -1;
    }

}
