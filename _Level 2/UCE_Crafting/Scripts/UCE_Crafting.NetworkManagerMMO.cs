// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Linq;

#if _iMMOCRAFTING

// NETWORK MANAGER MMO

public partial class NetworkManagerMMO
{
    // -----------------------------------------------------------------------------------
    // OnServerCharacterCreate_UCE_Crafting
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnServerCharacterCreate")]
    private void OnServerCharacterCreate_UCE_Crafting(CharacterCreateMsg message, Player player)
    {

        // -- check starting craft professions
        foreach (UCE_DefaultCraftingProfession craft in player.startingCrafts)
        {
            if (!player.UCE_HasCraftingProfession(craft.craftProfession))
            {
                UCE_CraftingProfession tmpProf = new UCE_CraftingProfession(craft.craftProfession.name);
                tmpProf.experience = craft.startingExp;
                player.UCE_Crafts.Add(tmpProf);
            }
        }

        // -- check starting recipes
        foreach (UCE_Tmpl_Recipe recipe in player.startingRecipes)
        {
            if (!player.UCE_recipes.Any(r => r == recipe.name))
                player.UCE_recipes.Add(recipe.name);
        }
    }

    // -----------------------------------------------------------------------------------
}

#endif
