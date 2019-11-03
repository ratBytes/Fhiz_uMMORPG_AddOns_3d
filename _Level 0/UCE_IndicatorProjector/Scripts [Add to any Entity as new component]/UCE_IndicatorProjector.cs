// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;
using Mirror;
using System;
using System.Linq;
using System.Collections;

// UCE_IndicatorProjector

public partial class UCE_IndicatorProjector : MonoBehaviour
{
    public GameObject indicatorProjector;
    public float hideAfter;

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show()
    {
        if (indicatorProjector)
        {
            indicatorProjector.gameObject.SetActive(true);
            Invoke("Hide", hideAfter);
        }
    }

    // -----------------------------------------------------------------------------------
    // Hide
    // -----------------------------------------------------------------------------------
    public void Hide()
    {
        if (indicatorProjector)
            indicatorProjector.gameObject.SetActive(false);
    }

    // -----------------------------------------------------------------------------------
}