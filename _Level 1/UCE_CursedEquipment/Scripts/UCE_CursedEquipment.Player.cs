// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using Mirror;

// PLAYER

public partial class Player
{
    // -----------------------------------------------------------------------------------
    // CmdSwapEquipInventory
    // -----------------------------------------------------------------------------------
    [Command]
    public void CmdSwapEquipInventory(int equipmentIndex, int inventoryIndex)
    {
        // validate: make sure that the slots actually exist in the inventory
        // and in the equipment
        if (isAlive &&
            0 <= inventoryIndex && inventoryIndex < inventory.Count &&
            0 <= equipmentIndex && equipmentIndex < equipment.Count)
        {
            // equipment slot has to be empty (unequip) or un-equipable
            ItemSlot slot = equipment[equipmentIndex];

            if (slot.amount == 0 ||
                slot.item.data is EquipmentItem &&
                ((EquipmentItem)slot.item.data).CanUnequip(this, inventoryIndex, equipmentIndex))
            {
                // swap them
                ItemSlot temp = inventory[inventoryIndex];
                inventory[inventoryIndex] = slot;
                equipment[equipmentIndex] = temp;
            }
        }
    }

    // -----------------------------------------------------------------------------------
    // OnDragAndDrop_EquipmentSlot_InventorySlot
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnDragAndDrop")]
    private void OnDragAndDrop_EquipmentSlot_InventorySlot(int[] slotIndices)
    {
        // slotIndices[0] = slotFrom; slotIndices[1] = slotTo
        CmdSwapEquipInventory(slotIndices[0], slotIndices[1]);
    }

    // -----------------------------------------------------------------------------------
}
