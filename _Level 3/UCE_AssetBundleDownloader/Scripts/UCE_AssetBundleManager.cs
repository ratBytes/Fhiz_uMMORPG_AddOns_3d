// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// ===================================================================================
// AssetBundleManager (SINGLETON)
// ===================================================================================
public class UCE_AssetBundleManager : MonoBehaviour
{
   
    public static UCE_AssetBundleManager singleton;

    [Tooltip("[Required] Assign your UCE Jukebox Template here")]
    public UCE_Tmpl_Jukebox jukeboxTemplate;

    private void Awake()
    {
        if (singleton == null) singleton = this;
    }

    // ===============================================================================
    // GENERAL FUNCTIONS
    // ===============================================================================


    // -------------------------------------------------------------------------------
}

// ===================================================================================
