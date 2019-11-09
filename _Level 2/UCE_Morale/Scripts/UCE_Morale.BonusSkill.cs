// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Text;
using UnityEngine;
using Mirror;

// BONUS SKILL

public abstract partial class BonusSkill : ScriptableSkill
{
    public bool blockMoraleRecovery;
    public LinearInt bonusMoraleMax;
    public LinearFloat bonusMoralePercentPerSecond;
}
