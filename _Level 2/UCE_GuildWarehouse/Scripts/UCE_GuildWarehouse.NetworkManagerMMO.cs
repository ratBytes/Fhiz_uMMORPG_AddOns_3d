// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using Mirror;

// NETWORK MANAGER

public partial class NetworkManagerMMO
{
    // -----------------------------------------------------------------------------------
    // OnServerDisconnect
    // @Server
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnServerDiconnect")]
    private void OnServerDisconnect_UCE_GuildUCE_warehouse(NetworkConnection conn)
    {
        if (conn.identity != null)
            Database.singleton.UCE_SaveGuildWarehouse(conn.identity.GetComponent<Player>());
    }

    // -----------------------------------------------------------------------------------
}