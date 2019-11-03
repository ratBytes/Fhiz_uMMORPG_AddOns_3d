// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

// PLAYER

public partial class Player : Entity
{
    [HideInInspector] public int UCE_usageAreaId;

    // -----------------------------------------------------------------------------------
    // UCE_UsageAreaEnter
    // -----------------------------------------------------------------------------------
    public void UCE_UsageAreaEnter(int id)
    {
        if (id <= 0) return;
        UCE_usageAreaId = id;
    }

    // -----------------------------------------------------------------------------------
    // UCE_UsageAreaExit
    // -----------------------------------------------------------------------------------
    public void UCE_UsageAreaExit()
    {
        UCE_usageAreaId = 0;
    }

    // -----------------------------------------------------------------------------------
    // UCE_GetEquipmentId
    // -----------------------------------------------------------------------------------
    public bool UCE_GetEquipmentId(int id)
    {
        return equipment.FindIndex(slot => slot.amount > 0 &&
            ((EquipmentItem)slot.item.data).usageEquipmentId == id) != -1;
    }

    // -----------------------------------------------------------------------------------
}