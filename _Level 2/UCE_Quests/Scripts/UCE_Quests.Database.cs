// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System;
using System.Collections.Generic;

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
    // Connect_UCE_Quest
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Connect")]
    private void Connect_UCE_Quest()
    {
#if _MYSQL
		ExecuteNonQueryMySql(@"CREATE TABLE IF NOT EXISTS character_UCE_quests (
                            `character` VARCHAR(32) NOT NULL,
                            name VARCHAR(111) NOT NULL,
                            killed VARCHAR(111) NOT NULL,
                            gathered VARCHAR(111) NOT NULL,
                            harvested VARCHAR(111) NOT NULL,
                            visited VARCHAR(111) NOT NULL,
                            crafted VARCHAR(111) NOT NULL,
                            looted VARCHAR(111) NOT NULL,
                            completed INTEGER(16) NOT NULL,
                            completedAgain INTEGER(16) NOT NULL,
                            lastCompleted VARCHAR(111) NOT NULL,
                            counter INTEGER(16) NOT NULL,
                                PRIMARY KEY(`character`, name)
                            ) CHARACTER SET=utf8mb4");
#elif _SQLITE
        connection.CreateTable<character_UCE_quests>();
        connection.CreateIndex(nameof(character_UCE_quests), new[] { "character", "name" });
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterLoad_UCE_Quest
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterLoad")]
    private void CharacterLoad_UCE_Quest(Player player)
    {
#if _MYSQL
		List< List<object> > table = ExecuteReaderMySql("SELECT name, killed, gathered, harvested, visited, crafted, looted, completed, completedAgain, lastCompleted, counter FROM character_UCE_quests WHERE `character`=@character",
        					new MySqlParameter("@character", player.name));
        foreach (List<object> row in table)
        {
            string questName = (string)row[0];
            UCE_ScriptableQuest questData;
            if (UCE_ScriptableQuest.dict.TryGetValue(questName.GetStableHashCode(), out questData))
            {
                UCE_Quest quest 		= new UCE_Quest(questData);

                quest.killedTarget 		= UCE_Tools.IntStringToArray((string)row[1]);
                quest.gatheredTarget 	= UCE_Tools.IntStringToArray((string)row[2]);
                quest.harvestedTarget 	= UCE_Tools.IntStringToArray((string)row[3]);
                quest.visitedTarget 	= UCE_Tools.IntStringToArray((string)row[4]);
                quest.craftedTarget 	= UCE_Tools.IntStringToArray((string)row[5]);
                quest.lootedTarget 		= UCE_Tools.IntStringToArray((string)row[6]);

                foreach (int i in quest.visitedTarget)
                	if (i != 0) quest.visitedCount++;

                quest.completed 		= ((int)row[7]) != 0; // sqlite has no bool
                quest.completedAgain 	= ((int)row[8]) != 0; // sqlite has no bool
        		quest.lastCompleted 	= (string)row[9];
                quest.counter			= (int)row[10];
                player.UCE_quests.Add(quest);
            }
        }

#elif _SQLITE
        var table = connection.Query<character_UCE_quests>("SELECT name, pvped, killed, gathered, harvested, visited, crafted, looted, completed, completedAgain, lastCompleted, counter FROM character_UCE_quests WHERE character=?", player.name);
        foreach (var row in table)
        {
            string questName = row.name;
            UCE_ScriptableQuest questData;
            if (UCE_ScriptableQuest.dict.TryGetValue(questName.GetStableHashCode(), out questData))
            {
                UCE_Quest quest = new UCE_Quest(questData);

                quest.pvpedTarget = UCE_Tools.IntStringToArray(row.pvped);
                quest.killedTarget = UCE_Tools.IntStringToArray(row.killed);
                quest.gatheredTarget = UCE_Tools.IntStringToArray(row.gathered);
                quest.harvestedTarget = UCE_Tools.IntStringToArray(row.harvested);
                quest.visitedTarget = UCE_Tools.IntStringToArray(row.visited);
                quest.craftedTarget = UCE_Tools.IntStringToArray(row.crafted);
                quest.lootedTarget = UCE_Tools.IntStringToArray(row.looted);

                foreach (int i in quest.visitedTarget)
                    if (i != 0) quest.visitedCount++;

                quest.completed = row.completed;
                quest.completedAgain = row.completedAgain;
                quest.lastCompleted = row.lastCompleted;
                quest.counter = row.counter;
                player.UCE_quests.Add(quest);
            }
        }
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterSave_UCE_Quest
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterSave")]
    private void CharacterSave_UCE_Quest(Player player)
    {
#if _MYSQL
		var query2 = @"
            INSERT INTO character_UCE_quests
            SET
            `character`=@character,
            name=@name,
            killed=@killed,
            gathered=@gathered,
            harvested=@harvested,
            visited=@visited,
            crafted=@crafted,
            looted=@looted,
            completed=@completed,
            completedAgain=@completedAgain,
            lastCompleted=@lastCompleted,
            counter=@counter
            ON DUPLICATE KEY UPDATE
            name=@name,
            killed=@killed,
            gathered=@gathered,
            harvested=@harvested,
            visited=@visited,
            crafted=@crafted,
            looted=@looted,
            completed=@completed,
            completedAgain=@completedAgain,
            lastCompleted=@lastCompleted,
            counter=@counter
            ";

        foreach (UCE_Quest quest in player.UCE_quests)
            ExecuteNonQueryMySql(query2,
                            new MySqlParameter("@character", player.name),
                            new MySqlParameter("@name", quest.name),
                            new MySqlParameter("@killed", UCE_Tools.IntArrayToString(quest.killedTarget)),
                            new MySqlParameter("@gathered", UCE_Tools.IntArrayToString(quest.gatheredTarget)),
                            new MySqlParameter("@harvested", UCE_Tools.IntArrayToString(quest.harvestedTarget)),
                            new MySqlParameter("@visited", UCE_Tools.IntArrayToString(quest.visitedTarget)),
                            new MySqlParameter("@crafted", UCE_Tools.IntArrayToString(quest.craftedTarget)),
                            new MySqlParameter("@looted", UCE_Tools.IntArrayToString(quest.lootedTarget)),
                            new MySqlParameter("@completed", Convert.ToInt32(quest.completed)),
                            new MySqlParameter("@completedAgain", Convert.ToInt16(quest.completedAgain)),
                            new MySqlParameter("@lastCompleted", quest.lastCompleted),
                            new MySqlParameter("@counter", quest.counter)
                            );

#elif _SQLITE
        // quests: remove old entries first, then add all new ones
        connection.Execute("DELETE FROM character_UCE_quests WHERE character=?", player.name);
        foreach (UCE_Quest quest in player.UCE_quests)
            connection.Insert(new character_UCE_quests
            {
                character = player.name,
                name = quest.name,
                pvped = UCE_Tools.IntArrayToString(quest.killedTarget),
                killed = UCE_Tools.IntArrayToString(quest.killedTarget),
                gathered = UCE_Tools.IntArrayToString(quest.gatheredTarget),
                harvested = UCE_Tools.IntArrayToString(quest.harvestedTarget),
                visited = UCE_Tools.IntArrayToString(quest.visitedTarget),
                crafted = UCE_Tools.IntArrayToString(quest.craftedTarget),
                looted = UCE_Tools.IntArrayToString(quest.lootedTarget),
                completed = quest.completed,
                completedAgain = quest.completedAgain,
                lastCompleted = quest.lastCompleted,
                counter = quest.counter
            });
#endif
    }

    // -----------------------------------------------------------------------------------
}