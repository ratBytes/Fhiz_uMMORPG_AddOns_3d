// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

// TemplateEntityBlueprint

[CreateAssetMenu(menuName = "UCE Other/UCE Entity Blueprint", fileName = "New UCE Entity Blueprint", order = 999)]
public partial class UCE_TemplateEntityBlueprint : ScriptableObject
{

    [Header("Health")]
    public LinearInt healthMax = new LinearInt { baseValue = 100, bonusPerLevel = 0 };

    /*
     * TODO: add all other stats
     * like mana, crit rate, etc.
     * */    

    // -----------------------------------------------------------------------------------
    // OnValidate
    // -----------------------------------------------------------------------------------
    public void OnValidate()
    {
#if UNITY_EDITOR
        
#endif
    }

    // -----------------------------------------------------------------------------------
}
