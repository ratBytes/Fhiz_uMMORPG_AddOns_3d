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

// NPC DIALOGUE

public partial class UCE_UI_Mail_NpcDialogue : MonoBehaviour
{
    public GameObject panel;
    public GameObject npcMailReadPanel;
    public GameObject npcMailSendPanel;
    public Button npcMailReadButton;
    public Button npcMailSendButton;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    public void Update()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        // use collider point(s) to also work with big entities
        if (panel.activeSelf &&
            player.target != null && player.target is Npc &&
            Utils.ClosestDistance(player.collider, player.target.collider) <= player.interactionRange)
        {
            Npc npc = (Npc)player.target;

            npcMailReadButton.gameObject.SetActive(npc.offersMailRead);
            npcMailReadButton.onClick.SetListener(() =>
            {
                npcMailReadPanel.SetActive(true);
                panel.SetActive(false);
            });

            npcMailSendButton.gameObject.SetActive(npc.offersMailSend);
            npcMailSendButton.onClick.SetListener(() =>
            {
                npcMailSendPanel.SetActive(true);
                panel.SetActive(false);
            });
        }
    }

    // -----------------------------------------------------------------------------------
}
