// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

// NetworkManagerMMO

public partial class NetworkManagerMMO
{

    // -----------------------------------------------------------------------------------
    // Start_UCE_Tools
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Start")]
    private void Start_UCE_Tools()
    {
#if _SERVER && !_CLIENT
        StartServer();
#endif
    }

    // -----------------------------------------------------------------------------------
}
