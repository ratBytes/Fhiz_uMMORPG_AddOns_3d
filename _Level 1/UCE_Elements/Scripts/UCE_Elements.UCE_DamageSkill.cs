// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

#if _iMMOPROJECTILES || _iMMOMELEE

public abstract partial class UCE_DamageSkill : ScriptableSkill
{
    [Header("-=-=- UCE ELEMENTAL ATTACK -=-=-")]
    public UCE_ElementTemplate element;
}

#endif