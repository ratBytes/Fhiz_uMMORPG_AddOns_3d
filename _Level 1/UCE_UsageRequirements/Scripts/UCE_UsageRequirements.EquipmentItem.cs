// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

public partial class EquipmentItem : UsableItem
{
    [Header("-=-=- UCE Usage Requirements -=-=-")]
    [Tooltip("While equipped, allows the usage of skills with the same ID (0 = disabled)")]
    public int usageEquipmentId;
}