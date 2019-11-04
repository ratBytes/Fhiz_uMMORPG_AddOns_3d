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

// SHORTCUTS

public partial class UCE_UI_Mail_Shortcuts : MonoBehaviour
{
    public Button mailInboxButton;
    public Image mailButtonImage;
    public GameObject mailInboxPanel;

    public Sprite mailRead;
    public Sprite mailUnread;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    public void Update()
    {
        mailInboxButton.onClick.SetListener(() =>
        {
            mailInboxPanel.SetActive(!mailInboxPanel.activeSelf);
        });

        Player player = Player.localPlayer;
        if (player == null) return;

        if (player.UnreadMailCount() > 0)
            mailButtonImage.sprite = mailUnread;
        else
            mailButtonImage.sprite = mailRead;
    }

    // -----------------------------------------------------------------------------------
}
