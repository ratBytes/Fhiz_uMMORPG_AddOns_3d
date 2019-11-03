// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;
using UnityEngine.UI;

// UCE UI NPC GUILD UPGRADE DIALOGUE

public class UCE_UI_NpcGuildUpgradeDialogue : MonoBehaviour
{
    public GameObject panel;
    public Button guildUpgradeButton;
    public GameObject guildUpgradePanel;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (player.target != null &&
            player.target is Npc &&
            Utils.ClosestDistance(player.collider, player.target.collider) <= player.interactionRange)
        {
            Npc npc = (Npc)player.target;

            guildUpgradeButton.gameObject.SetActive(npc.checkGuildUpgradeAccess(player));

            guildUpgradeButton.onClick.SetListener(() =>
            {
                guildUpgradePanel.SetActive(true);
                panel.SetActive(false);
            });
        }
        else
        {
            guildUpgradePanel.SetActive(false);
        }
    }

    // -----------------------------------------------------------------------------------
}