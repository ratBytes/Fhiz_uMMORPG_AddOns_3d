// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

// UseItem

public class UseItem : MonoBehaviour
{
    public static void Use(UCE_Tmpl_PayPalProduct product)
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (product != null)
        {
            player.Cmd_UCE_PayPal_PurchaseCoins(product.name.GetStableHashCode());
        }
    }
}