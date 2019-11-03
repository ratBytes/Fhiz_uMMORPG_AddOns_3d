// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using Mirror;
using UnityEngine;

// PLAYER

public partial class Player
{
    [Header("-=-=-=- UCE SKILL EXP ON LEVEL UP -=-=-=-")]
    public LinearInt skillExpOnLevelUp;

    // -----------------------------------------------------------------------------------
    // OnLevelUp_UCE_LevelUpNotice
    // -----------------------------------------------------------------------------------
    [Server]
    [DevExtMethods("OnLevelUp")]
    private void OnLevelUp_UCE_SkillExpOnLevelUp()
    {
        skillExperience += skillExpOnLevelUp.Get(level);
    }
}