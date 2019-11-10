// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// REALM - TEMPLATE

[CreateAssetMenu(fileName = "UCE Realm", menuName = "UCE Templates/New UCE Realm", order = 998)]
public class UCE_Tmpl_Realm : ScriptableObject
{
    [Header("-=-=-=- UCE REALM -=-=-=-")]
    public Sprite image;

    [TextArea(1, 10)] public string description;

    // -----------------------------------------------------------------------------------
    // Caching
    // -----------------------------------------------------------------------------------
    private static Dictionary<int, UCE_Tmpl_Realm> cache;

    public static Dictionary<int, UCE_Tmpl_Realm> dict
    {
        get
        {
            // load if not loaded yet
            return cache ?? (cache = Resources.LoadAll<UCE_Tmpl_Realm>(UCE_TemplateConfiguration.singleton.GetTemplatePath(typeof(UCE_TemplateConfiguration))).ToDictionary(
                x => x.name.GetStableHashCode(), x => x)
            );
        }
    }

    // -----------------------------------------------------------------------------------
}
