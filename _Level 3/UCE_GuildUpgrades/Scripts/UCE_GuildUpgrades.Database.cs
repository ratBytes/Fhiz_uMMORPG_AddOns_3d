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
    // Connect_UCE_GuildUpgrades
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Connect")]
    private void Connect_UCE_GuildUpgrades()
    {
#if _MYSQL

		ExecuteNonQueryMySql(@"
            CREATE TABLE IF NOT EXISTS UCE_guild_upgrades(
			        guild VARCHAR(32) NOT NULL,
					level INTEGER(16) NOT NULL DEFAULT 0,
                    PRIMARY KEY(guild)
                  ) CHARACTER SET=utf8mb4");

#elif _SQLITE
        connection.CreateTable<UCE_guild_upgrades>();
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterSave_UCE_GuildUpgrades
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterSave")]
    private void CharacterSave_UCE_GuildUpgrades(Player player)
    {
        UCE_SaveGuildUpgrades(player);
    }

    // -----------------------------------------------------------------------------------
    // UCE_LoadGuildUpgrades
    // -----------------------------------------------------------------------------------
    public void UCE_LoadGuildUpgrades(Player player)
    {
        if (!player.InGuild()) return;

#if _MYSQL

		var guildLevel = ExecuteScalarMySql("SELECT level FROM UCE_guild_upgrades WHERE guild=@guild", new MySqlParameter("@guild", player.guild.name));

        // -- exists already? load to player

        if (guildLevel != null)
        {
            player.guildLevel = Convert.ToInt32((long)guildLevel);
            ExecuteNonQueryMySql("UPDATE UCE_guild_upgrades SET busy=1 WHERE guild=@guild", new MySqlParameter("@guild", 	player.guild.name));
        }
        else
        {
        	// -- does not exist? create new

            ExecuteNonQueryMySql("INSERT INTO UCE_guild_upgrades (guild, level) VALUES(@guild, 0)", new MySqlParameter("@guild", player.guild.name));

            player.guildLevel 	= 0;
        }

#elif _SQLITE

        var results = connection.FindWithQuery<UCE_guild_upgrades>("SELECT level FROM UCE_guild_upgrades WHERE guild=?", player.guild.name);
        int guildLevel = results.level;

        // -- exists already? load to player

        if (results != null)
        {
            player.guildLevel = guildLevel;
            connection.Execute("UPDATE UCE_guild_upgrades SET busy=1 WHERE guild=?", player.guild.name);
        }
        else
        {
            // -- does not exist? create new
            connection.Insert(new UCE_guild_upgrades
            {
                guild = player.guild.name,
                level = 0
            });
            player.guildLevel = 0;
        }

#endif

        player.guildWarehouseActionDone = false;
    }

    // -----------------------------------------------------------------------------------
    // UCE_SaveGuildUpgrades
    // -----------------------------------------------------------------------------------
    public void UCE_SaveGuildUpgrades(Player player)
    {
        if (!player.InGuild()) return;

#if _MYSQL
		ExecuteNonQueryMySql("DELETE FROM UCE_guild_upgrades WHERE guild=@guild", new MySqlParameter("@guild", player.guild.name));
		ExecuteNonQueryMySql("INSERT INTO UCE_guild_upgrades (guild, level) VALUES(@guild, @level)",
			new MySqlParameter("@level", 	player.guildLevel),
			new MySqlParameter("@guild", 	player.guild.name));

#elif _SQLITE
        connection.Execute("DELETE FROM UCE_guild_upgrades WHERE guild=?", player.guild.name);
        connection.Insert(new UCE_guild_upgrades
        {
            guild = player.guild.name,
            level = player.guildLevel
        });
#endif
    }

    // -----------------------------------------------------------------------------------
}