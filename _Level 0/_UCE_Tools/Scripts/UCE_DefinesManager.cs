// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public partial class UCE_DefinesManager
{

    protected static List<string> defines = new List<string>();

    static UCE_DefinesManager()
    {
        Utils.InvokeMany(typeof(UCE_DefinesManager), null, "Constructor_");

        foreach (string define in defines)
            UCE_EditorTools.AddScriptingDefine(define);

    }

}

#endif
