// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
// EQUIPMENT ITEM

public partial class EquipmentItem
{
    // -----------------------------------------------------------------------------------
    // CanUnequip (Swapping)
    // -----------------------------------------------------------------------------------
    public bool CanUnequip(Player player, int inventoryIndex, int equipmentIndex)
    {
        MutableWrapper<bool> bValid = new MutableWrapper<bool>(true);
        Utils.InvokeMany(typeof(EquipmentItem), this, "CanUnequip_", player, inventoryIndex, equipmentIndex, bValid);
        return bValid.Value;
    }

    // -----------------------------------------------------------------------------------
    // CanUnequipClick (Clicking)
    // -----------------------------------------------------------------------------------
    public bool CanUnequipClick(Player player, EquipmentItem item)
    {
        MutableWrapper<bool> bValid = new MutableWrapper<bool>(true);
        Utils.InvokeMany(typeof(EquipmentItem), this, "CanUnequipClick_", player, item, bValid);
        return bValid.Value;
    }

    // -----------------------------------------------------------------------------------
}