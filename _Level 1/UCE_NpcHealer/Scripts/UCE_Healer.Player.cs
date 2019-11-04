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
    // Cmd_UCE_Healer
    // @Client -> @Server
    // -----------------------------------------------------------------------------------
    [Command]
    public void Cmd_UCE_Healer()
    {
        if (state == "IDLE" &&
            target != null &&
            target.isAlive &&
            isAlive &&
            target is Npc &&
            Utils.ClosestDistance(collider, target.collider) <= interactionRange &&
            ((Npc)target).healingServices.Valid(this))
        {
            Npc npc = (Npc)target;

            gold -= npc.healingServices.getCost(this);

            if (npc.healingServices.healHealth)
                health = healthMax;

            if (npc.healingServices.healMana)
                mana = manaMax;

            if (npc.healingServices.removeBuffs)
                UCE_CleanupStatusBuffs();

            if (npc.healingServices.removeNerfs)
                UCE_CleanupStatusNerfs();

#if _iMMOCURSEDEQUIPMENT && _iMMOTOOLS
            if (npc.healingServices.unequipMaxCursedLevel > 0)
                UCE_UnequipCursedEquipment(npc.healingServices.unequipMaxCursedLevel); // in Tools
#endif
        }
    }

    // -----------------------------------------------------------------------------------
}
