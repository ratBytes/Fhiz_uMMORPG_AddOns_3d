// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using Mirror;
using System.Linq;
using UnityEngine;

// PLAYER

public partial class Player
{
    [Header("UCE STAMINA SYSTEM")]
    public TargetBuffSkill exhaustedBuff;
    public int maxExhaustedBuffLevel = 1;

    protected float _updateTimerStamina;

    // -----------------------------------------------------------------------------------
    // Update_UCE_Stamina
    // @Server
    // -----------------------------------------------------------------------------------
    [ServerCallback]
    [DevExtMethods("Update")]
    private void Update_UCE_Stamina()
    {
        if (exhaustedBuff == null || !isServer) return;

        // -- Delayed Update (once per second instead of once per frame)

        if (Time.time > _updateTimerStamina)
        {

            // -- apply or remove burdened
            if (stamina <= 0)
            {
                AddOrRefreshBuff(new Buff(exhaustedBuff, maxExhaustedBuffLevel));
            }
            else
            {
                UCE_RemoveBuff(exhaustedBuff);
            }

            _updateTimerStamina = Time.time + cacheTimerInterval;
        }
    }

    // -----------------------------------------------------------------------------------
}
