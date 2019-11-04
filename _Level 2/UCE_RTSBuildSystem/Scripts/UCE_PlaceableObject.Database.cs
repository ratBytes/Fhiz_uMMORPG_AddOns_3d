// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;
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
    // Connect_UCE_PlaceableObject
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Connect")]
    private void Connect_UCE_PlaceableObject()
    {
#if _MYSQL
		ExecuteNonQueryMySql(@"CREATE TABLE IF NOT EXISTS placeable_objects (
				`character` VARCHAR(32) NOT NULL,
				guild VARCHAR(32) NOT NULL,
				x FLOAT NOT NULL,
            	y FLOAT NOT NULL,
            	z FLOAT NOT NULL,
            	xRot FLOAT NOT NULL,
            	yRot FLOAT NOT NULL,
            	zRot FLOAT NOT NULL,
            	level INT NOT NULL,
                item VARCHAR(64) NOT NULL,
                id INT NOT NULL
                )");
#elif _SQLITE
        connection.CreateTable<placeable_objects>();
#endif
    }

    // -----------------------------------------------------------------------------------
    // UCE_SavePlaceableObject
    // -----------------------------------------------------------------------------------
    public void UCE_SavePlaceableObject(string character, string guild, GameObject placeableObject, int level, string itemName, int id)
    {
        Vector3 position = placeableObject.transform.position;
        Vector3 rotation = placeableObject.transform.rotation.eulerAngles;
#if _MYSQL
		ExecuteNonQueryMySql("INSERT INTO placeable_objects VALUES (@character, @guild, @x, @y, @z, @xRot, @yRot, @zRot, @level, @item, @id)",
				new MySqlParameter("@character", 	character),
				new MySqlParameter("@guild", 		guild == null ? "" : guild),
				new MySqlParameter("@x", 			position.x),
				new MySqlParameter("@y", 			position.y),
				new MySqlParameter("@z", 			position.z),
				new MySqlParameter("@xRot", 		rotation.x),
				new MySqlParameter("@yRot", 		rotation.y),
				new MySqlParameter("@zRot", 		rotation.z),
				new MySqlParameter("@level", 		level),
				new MySqlParameter("@item", 		itemName),
				new MySqlParameter("@id", 			id)
				);
#elif _SQLITE
        connection.Insert(new placeable_objects
        {
            character = character,
            guild = guild == null ? "" : guild,
            x = position.x,
            y = position.y,
            z = position.z,
            xRot = rotation.x,
            yRot = rotation.y,
            zRot = rotation.z,
            level = level,
            item = itemName,
            id = id
        });
#endif
    }

    // -----------------------------------------------------------------------------------
    // UCE_DeletePlaceableObject
    // -----------------------------------------------------------------------------------
    public void UCE_DeletePlaceableObject(string character, string guild, int level, string itemName, int id)
    {
#if _MYSQL
		ExecuteNonQueryMySql("DELETE FROM placeable_objects WHERE (`character`=@character AND guild=@guild AND level=@level AND item=@item AND id=@id)",
				new MySqlParameter("@character", 	character),
				new MySqlParameter("@guild", 		guild == null ? "" : guild),
				new MySqlParameter("@level", 		level),
				new MySqlParameter("@item", 		itemName),
				new MySqlParameter("@id", 			id)
				);
#elif _SQLITE
        connection.Execute("DELETE FROM placeable_objects WHERE (character=? AND guild=? AND level=? AND item=? AND id=?)", character, guild == null ? "" : guild, level, itemName, id);
#endif
    }

#if _MYSQL
    // -----------------------------------------------------------------------------------
    // MySql UCE_LoadPlaceableObjects
    // -----------------------------------------------------------------------------------
    public List<List<object>> UCE_LoadPlaceableObjects()
    {
        List<List<object>> objects = new List<List<object>>();

		if (0 < (long)Database.singleton.ExecuteScalarMySql("SELECT count(*) FROM placeable_objects"))
			objects = Database.singleton.ExecuteReaderMySql("SELECT `character`, guild, x, y, z, xRot, yRot, zRot, level, item, id FROM placeable_objects");

        return objects;
    }
#endif

#if _SQLITE

    // -----------------------------------------------------------------------------------
    // Sqlite UCE_LoadPlaceableObjects
    // -----------------------------------------------------------------------------------
    public List<placeable_objects> UCE_LoadPlaceableObjects()
    {
        List<placeable_objects> objects = new List<placeable_objects>();

        var results = connection.Query<placeable_objects>("SELECT count(*) FROM placeable_objects");
        if (0 < results.Count)
            objects = connection.Query<placeable_objects>("SELECT character, guild, x, y, z, xRot, yRot, zRot, level, item, id FROM placeable_objects");

        return objects;
    }

#endif

    // -----------------------------------------------------------------------------------
}
