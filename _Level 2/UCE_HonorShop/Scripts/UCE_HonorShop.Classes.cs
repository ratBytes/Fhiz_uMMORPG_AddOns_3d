// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System;

// UCE_HonorShopCategory

[Serializable]
public partial struct UCE_HonorShopCategory
{
    public string categoryName;
    public UCE_Tmpl_HonorCurrency honorCurrency;
    public ScriptableItem[] items;
}