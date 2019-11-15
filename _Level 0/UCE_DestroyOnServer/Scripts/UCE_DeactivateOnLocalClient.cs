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

// DEACTIVATE ON lOCAL CLIENT

public class UCE_DeactivateOnLocalClient : MonoBehaviour
{
    // -------------------------------------------------------------------------------
    // Start
    // -------------------------------------------------------------------------------
    private void Start()
    {
#if _CIENT && !_SERVER
        Player player = Player.localPlayer;
        if (player)
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);
#else
        this.gameObject.SetActive(true);
#endif
    }

    // -------------------------------------------------------------------------------
}
