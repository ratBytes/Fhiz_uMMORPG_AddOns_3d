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

// DEACTIVATE ON SERVER

public class UCE_DeactivateOnServer : MonoBehaviour
{
    // -------------------------------------------------------------------------------
    // Start
    // -------------------------------------------------------------------------------
    private void Start()
    {
#if _SERVER && !_CLIENT
        this.gameObject.SetActive(false);
#else
        this.gameObject.SetActive(true);
#endif
    }

    // -------------------------------------------------------------------------------
}
