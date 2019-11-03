// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

// DATABASE CLEANER

[CreateAssetMenu(fileName = "UCE WordFilter", menuName = "UCE Templates/New UCE WordFilter", order = 999)]
public class UCE_Tmpl_WordFilter : ScriptableObject
{
    [Tooltip("[Required] Enter all bad words here. If a chatext or player name contains one of them, it will be denied.")]
    public string[] badwords;
}