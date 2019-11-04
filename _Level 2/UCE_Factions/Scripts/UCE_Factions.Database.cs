// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System;

#if _MYSQL
using MySql.Data;								// From MySql.Data.dll in Plugins folder
using MySql.Data.MySqlClient;                   // From MySql.Data.dll in Plugins folder
#elif _SQLITE

using SQLite; 						// copied from Unity/Mono/lib/mono/2.0 to Plugins

#endif

// DATABASE (SQLite / mySQL Hybrid)

public partial class Database
{
    // -----------------------------------------------------------------------------------
    // Connect_UCE_Factions
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Connect")]
    private void Connect_UCE_Factions()
    {
#if _MYSQL
		ExecuteNonQueryMySql(@"CREATE TABLE IF NOT EXISTS character_factions (
        				`character` VARCHAR(32) NOT NULL,
        				faction VARCHAR(32)  NOT NULL,
        				rating INTEGER(15)
        				) CHARACTER SET=utf8mb4 ");
#elif _SQLITE
        connection.CreateTable<character_factions>();
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterLoad_UCE_Factions
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterLoad")]
    private void CharacterLoad_UCE_Factions(Player player)
    {
#if _MYSQL
		var table = ExecuteReaderMySql("SELECT faction, rating FROM character_factions WHERE `character`=@character", new MySqlParameter("@character", player.name));

        foreach (var row in table) {
            UCE_Faction faction 	= new UCE_Faction();
            faction.name 			= (string)row[0];
            faction.rating 			= Convert.ToInt32(row[1]);
            player.UCE_Factions.Add(faction);
        }
#elif _SQLITE
        var table = connection.Query<character_factions>("SELECT faction, rating FROM character_factions WHERE character=?", player.name);

        foreach (var row in table)
        {
            UCE_Faction faction = new UCE_Faction();
            faction.name = row.faction;
            faction.rating = row.rating;
            player.UCE_Factions.Add(faction);
        }
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterSave_UCE_Factions
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterSave")]
    private void CharacterSave_UCE_Factions(Player player)
    {
#if _MYSQL
		ExecuteNonQueryMySql("DELETE FROM character_factions WHERE `character`=@character", new MySqlParameter("@character", player.name));
        foreach (UCE_Faction faction in player.UCE_Factions)
            ExecuteNonQueryMySql("INSERT INTO character_factions VALUES (@character, @faction, @rating)",
                            new MySqlParameter("@character", player.name),
                            new MySqlParameter("@faction", faction.name),
                            new MySqlParameter("@rating", faction.rating));
#elif _SQLITE
        connection.Execute("DELETE FROM character_factions WHERE character=?", player.name);
        foreach (UCE_Faction faction in player.UCE_Factions)
            connection.Insert(new character_factions
            {
                character = player.name,
                faction = faction.name,
                rating = faction.rating
            });
#endif
    }

    // -----------------------------------------------------------------------------------
}
