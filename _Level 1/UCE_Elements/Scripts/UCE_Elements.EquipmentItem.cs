// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Linq;
using UnityEngine;

// EQUIPMENT ITEM

public partial class EquipmentItem
{
    [Header("-=-=- UCE ELEMENTAL ATTACK -=-=-")]
    public UCE_ElementTemplate elementalAttack;

    [Header("-=-=- UCE ELEMENTAL RESISTANCES -=-=-")]
    public UCE_ElementModifier[] elementalResistances;

    public float GetResistance(UCE_ElementTemplate element)
    {
        if (elementalResistances.Any(x => x.template == element))
            return elementalResistances.FirstOrDefault(x => x.template == element).value;
        else
            return 0;
    }

    // -----------------------------------------------------------------------------------
}
