// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
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
    // Connect_UCE_Travelroutes
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Connect")]
    private void Connect_UCE_Travelroutes()
    {
#if _MYSQL
		ExecuteNonQueryMySql(@"CREATE TABLE IF NOT EXISTS character_travelroutes (
				`character` VARCHAR(32) NOT NULL,
				travelroute VARCHAR(32) NOT NULL
				) CHARACTER SET=utf8mb4 ");
#elif _SQLITE
        connection.CreateTable<character_travelroutes>();
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterLoad_UCE_Travelroutes
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterLoad")]
    private void CharacterLoad_UCE_Travelroutes(Player player)
    {
#if _MYSQL
		var table = ExecuteReaderMySql("SELECT travelroute FROM character_travelroutes WHERE `character`=@name", new MySqlParameter("@name", player.name));
		foreach (var row in table) {
			UCE_TravelrouteClass tRoute = new UCE_TravelrouteClass((string)row[0]);
			player.UCE_travelroutes.Add(tRoute);
		}
#elif _SQLITE
        var table = connection.Query<character_travelroutes>("SELECT travelroute FROM character_travelroutes WHERE character=?", player.name);
        foreach (var row in table)
        {
            UCE_TravelrouteClass tRoute = new UCE_TravelrouteClass(row.travelroute);
            player.UCE_travelroutes.Add(tRoute);
        }
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterSave_UCE_Travelroutes
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterSave")]
    private void CharacterSave_UCE_Travelroutes(Player player)
    {
#if _MYSQL
		ExecuteNonQueryMySql("DELETE FROM character_travelroutes WHERE `character`=@character", new MySqlParameter("@character", player.name));
		for (int i = 0; i < player.UCE_travelroutes.Count; ++i) {
            ExecuteNonQueryMySql("INSERT INTO character_travelroutes VALUES (@character, @travelroute)",
 				new MySqlParameter("@character", player.name),
 				new MySqlParameter("@travelroute", player.UCE_travelroutes[i].name));
 		}
#elif _SQLITE
        connection.Execute("DELETE FROM character_travelroutes WHERE character=?", player.name);
        for (int i = 0; i < player.UCE_travelroutes.Count; ++i)
        {
            connection.Insert(new character_travelroutes
            {
                character = player.name,
                travelroute = player.UCE_travelroutes[i].name
            });
        }
#endif
    }

    // -----------------------------------------------------------------------------------
}