// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Collections.Generic;

#if _MYSQL

using MySql.Data;								// From MySql.Data.dll in Plugins folder
using MySql.Data.MySqlClient;                   // From MySql.Data.dll in Plugins folder

#elif _SQLITE
#endif

// DATABASE (SQLite / mySQL Hybrid)

public partial class Database
{
    // -----------------------------------------------------------------------------------
    // CharacterSaveMany
    // -----------------------------------------------------------------------------------
    public void CharacterSaveMany(IEnumerable<Player> players, bool online = true)
    {
#if _SERVER
#if _MYSQL
     		UCE_LoomManager.Loom.QueueOnMainThread(() =>
    			{
    				CharacterSaveMany_mySQL(players, online);
    			});
#elif _SQLITE
        UCE_LoomManager.Loom.QueueOnMainThread(() =>
            {
                CharacterSaveMany_SQLite(players, online);
            });
#endif
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterSaveMany_SQLite
    // -----------------------------------------------------------------------------------
#if _SQLITE && _SERVER

    [DevExtMethods("CharacterSaveMany")]
    private void CharacterSaveMany_SQLite(IEnumerable<Player> players, bool online = true)
    {
        connection.BeginTransaction();
        foreach (Player player in players)
        {
            if (player != null)
                CharacterSave(player, online, false);
        }
        connection.Commit();
    }

#endif

    // -----------------------------------------------------------------------------------
    // CharacterSaveMany_mySQL
    // -----------------------------------------------------------------------------------
#if _MYSQL && _SERVER
    [DevExtMethods("CharacterSaveMany")]
    private  void CharacterSaveMany_mySQL(IEnumerable<Player> players, bool online = true)
    {
        Transaction(command =>
        {
            foreach (Player player in players) {
            	if (player != null)
                	CharacterSave(player, online, command);
            }
        });
    }
#endif

    // -----------------------------------------------------------------------------------
}
