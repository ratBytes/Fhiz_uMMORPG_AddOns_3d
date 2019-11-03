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

#if _iMMOCRAFTING

// DATABASE (SQLite / mySQL Hybrid)

public partial class Database
{
    // -----------------------------------------------------------------------------------
    // Connect_UCE_Crafting
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Connect")]
    private void Connect_UCE_Crafting()
    {
#if _MYSQL
		ExecuteNonQueryMySql(@"CREATE TABLE IF NOT EXISTS character_crafts (
			`character` VARCHAR(32) NOT NULL,
			profession VARCHAR(32) NOT NULL,
			experience BIGINT
            ) CHARACTER SET=utf8mb4");

        ExecuteNonQueryMySql(@"CREATE TABLE IF NOT EXISTS character_recipes (
			`character` VARCHAR(32) NOT NULL,
			recipe VARCHAR(32) NOT NULL
             ) CHARACTER SET=utf8mb4");
#elif _SQLITE
        connection.CreateTable<character_crafts>();
        connection.CreateIndex(nameof(character_crafts), new[] { "character", "profession" });
        connection.CreateTable<character_recipes>();
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterLoad_UCE_Crafting
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterLoad")]
    private void CharacterLoad_UCE_Crafting(Player player)
    {
#if _MYSQL
		var table = ExecuteReaderMySql("SELECT profession, experience FROM character_crafts WHERE `character`=@character",
                    new MySqlParameter("@character", player.name));

        foreach (var row in table)
        {
            UCE_CraftingProfession profession = new UCE_CraftingProfession((string)row[0]);
            profession.experience = (long)row[1];
            player.UCE_Crafts.Add(profession);
        }

        var table2 = ExecuteReaderMySql("SELECT recipe FROM character_recipes WHERE `character`=@name", new MySqlParameter("@name", player.name));
        foreach (var row in table2)
        {
            player.UCE_recipes.Add((string)row[0]);
        }
#elif _SQLITE
        var table = connection.Query<character_crafts>("SELECT profession, experience FROM character_crafts WHERE character=?", player.name);
        foreach (var row in table)
        {
            UCE_CraftingProfession profession = new UCE_CraftingProfession(row.profession);
            profession.experience = row.experience;
            player.UCE_Crafts.Add(profession);
        }

        var table2 = connection.Query<character_recipes>("SELECT recipe FROM character_recipes WHERE character=?", player.name);
        foreach (var row in table2)
            player.UCE_recipes.Add(row.recipe);
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterSave_UCE_Crafting
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterSave")]
    private void CharacterSave_UCE_Crafting(Player player)
    {
#if _MYSQL
		ExecuteNonQueryMySql("DELETE FROM character_crafts WHERE `character`=@character", new MySqlParameter("@character", player.name));
        foreach (var profession in player.UCE_Crafts)
            ExecuteNonQueryMySql("INSERT INTO character_crafts VALUES (@character, @profession, @experience)",
                            new MySqlParameter("@character", player.name),
                            new MySqlParameter("@profession", profession.templateName),
                            new MySqlParameter("@experience", profession.experience));

        ExecuteNonQueryMySql("DELETE FROM character_recipes WHERE `character`=@character", new MySqlParameter("@character", player.name));
        for (int i = 0; i < player.UCE_recipes.Count; ++i)
        {
            ExecuteNonQueryMySql("INSERT INTO character_recipes VALUES (@character, @recipe)",
                 new MySqlParameter("@character", player.name),
                 new MySqlParameter("@recipe", player.UCE_recipes[i]));
        }
#elif _SQLITE
        connection.Execute("DELETE FROM character_crafts WHERE character=?", player.name);
        foreach (var profession in player.UCE_Crafts)
            connection.InsertOrReplace(new character_crafts
            {
                character = player.name,
                profession = profession.templateName,
                experience = profession.experience
            });

        connection.Execute("DELETE FROM character_recipes WHERE character=?", player.name);
        for (int i = 0; i < player.UCE_recipes.Count; ++i)
        {
            connection.InsertOrReplace(new character_recipes
            {
                character = player.name,
                recipe = player.UCE_recipes[i]
            });
        }
#endif
    }

    // -----------------------------------------------------------------------------------
}

#endif