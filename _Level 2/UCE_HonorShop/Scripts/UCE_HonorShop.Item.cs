// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Linq;

// ITEM

public partial struct Item
{
    // -----------------------------------------------------------------------------------
    // UCE_GetHonorCurrency
    // -----------------------------------------------------------------------------------
    public long UCE_GetHonorCurrency(UCE_Tmpl_HonorCurrency honorCurrency)
    {
        return data.currencyCosts.FirstOrDefault(x => x.honorCurrency.name == honorCurrency.name).amount;
    }
}