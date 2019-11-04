// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using SQLite;

// DATABASE CLASSES

public partial class Database
{
    #region Custom Database Classes

#if _SQLITE
    // -----------------------------------------------------------------------------------
    // Account Unlockables
    // -----------------------------------------------------------------------------------
    class account_unlockables
    {
        public string account { get; set; }
        public string unlockable { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Account Admin
    // -----------------------------------------------------------------------------------
    class account_admin
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string account { get; set; }
        public int admin { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // UCE Attributes
    // -----------------------------------------------------------------------------------
    class UCE_attributes
    {
        public string character { get; set; }
        public int slot { get; set; }
        public string name { get; set; }
        public int points { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Bindpoint
    // -----------------------------------------------------------------------------------
    class character_bindpoint
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string character { get; set; }
        public string name { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public string sceneName { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Crafts
    // -----------------------------------------------------------------------------------
    class character_crafts
    {
        public string character { get; set; }
        public string profession { get; set; }
        public long experience { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Recipes
    // -----------------------------------------------------------------------------------
    class character_recipes
    {
        public string character { get; set; }
        public string recipe { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Last Online
    // -----------------------------------------------------------------------------------
    class character_lastonline
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string character { get; set; }
        public string lastOnline { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Daily Rewards
    // -----------------------------------------------------------------------------------
    class character_dailyrewards
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string character { get; set; }
        public int counter { get; set; }
        public double resetTime { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Account Last Online
    // -----------------------------------------------------------------------------------
    class account_lastonline
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string account { get; set; }
        public string lastOnline { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Exploration
    // -----------------------------------------------------------------------------------
    class character_exploration
    {
        public string character { get; set; }
        public string exploredArea { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Factions
    // -----------------------------------------------------------------------------------
    class character_factions
    {
        public string character { get; set; }
        public string faction { get; set; }
        public int rating { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Friends
    // -----------------------------------------------------------------------------------
    class character_friends
    {
        public string character { get; set; }
        public string friendName { get; set; }
        public string lastGifted { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // UCE Guild Upgrades
    // -----------------------------------------------------------------------------------
    class UCE_guild_upgrades
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string guild { get; set; }
        public int level { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // UCE Guild Warehouse
    // -----------------------------------------------------------------------------------
    class UCE_guild_warehouse
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string guild { get; set; }
        public int gold { get; set; }
        public int level { get; set; }
        public int locked { get; set; }
        public int busy { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // UCE Guild Warehouse Items
    // -----------------------------------------------------------------------------------
    class UCE_guild_warehouse_items
    {
        public string guild { get; set; }
        public int slot { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public int summonedHealth { get; set; }
        public int summonedLevel { get; set; }
        public long summonedExperience { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Professions
    // -----------------------------------------------------------------------------------
    class character_professions
    {
        public string character { get; set; }
        public string profession { get; set; }
        public long experience { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // UCE Reports
    // -----------------------------------------------------------------------------------
    class UCE_reports
    {
        public string senderAcc { get; set; }
        public string senderCharacter { get; set; }
        public bool readBefore { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public bool solved { get; set; }
        public string time { get; set; }
        public string position { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Currencies
    // -----------------------------------------------------------------------------------
    class character_currencies
    {
        public string character { get; set; }
        public string currency { get; set; }
        public long amount { get; set; }
        public long total { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Mail
    // -----------------------------------------------------------------------------------
    public class mail
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public int id { get; set; }
        public string messageFrom { get; set; }
        public string messageTo { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public long sent { get; set; }
        public long expires { get; set; }
        public int read { get; set; }
        public int deleted { get; set; }
        public string item { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Scene
    // -----------------------------------------------------------------------------------
    class character_scene
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string character { get; set; }
        public string scene { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Zones Online
    // -----------------------------------------------------------------------------------
    class zones_online
    {
        public string online { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Purchases
    // -----------------------------------------------------------------------------------
    class character_purchases
    {
        public string character { get; set; }
        public string product { get; set; }
        public string purchased { get; set; }
        public int counter { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Prestige Classes
    // -----------------------------------------------------------------------------------
    class character_prestigeclasses
    {
        public string character { get; set; }
        public string class1 { get; set; }
        public string class2 { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Pvp Zones
    // -----------------------------------------------------------------------------------
    class character_pvpzones
    {
        public string character { get; set; }
        public string realm { get; set; }
        public string alliedrealm { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character UCE Quests
    // -----------------------------------------------------------------------------------
    class character_UCE_quests
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string character { get; set; }
        [Indexed]
        public string name { get; set; }
        public string pvped { get; set; }
        public string killed { get; set; }
        public string gathered { get; set; }
        public string harvested { get; set; }
        public string visited { get; set; }
        public string crafted { get; set; }
        public string looted { get; set; }
        public bool completed { get; set; }
        public bool completedAgain { get; set; }
        public string lastCompleted { get; set; }
        public int counter { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Placeable Objects
    // -----------------------------------------------------------------------------------
    public class placeable_objects
    {
        public string character { get; set; }
        public string guild { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float xRot { get; set; }
        public float yRot { get; set; }
        public float zRot { get; set; }
        public int level { get; set; }
        public string item { get; set; }
        public int id { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Timegates
    // -----------------------------------------------------------------------------------
    class character_timegates
    {
        public string character { get; set; }
        public string timegateName { get; set; }
        public int timegateCount { get; set; }
        public string timegateHours { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character UCE Traits
    // -----------------------------------------------------------------------------------
    class character_UCE_traits
    {
        public string character { get; set; }
        public string name { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Character Travel Routes
    // -----------------------------------------------------------------------------------
    class character_travelroutes
    {
        public string character { get; set; }
        public string travelroute { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // Account Unlocked Classes
    // -----------------------------------------------------------------------------------
    class account_unlockedclasses
    {
        public string account { get; set; }
        public string classname { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // UCE Warehouse
    // -----------------------------------------------------------------------------------
    class uce_warehouse
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string character { get; set; }
        public int gold { get; set; }
        public int level { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // UCE Warehouse Items
    // -----------------------------------------------------------------------------------
    class uce_warehouse_items
    {
        public string character { get; set; }
        public int slot { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public int summonedHealth { get; set; }
        public int summonedLevel { get; set; }
        public long summonedExperience { get; set; }
    }

    // -----------------------------------------------------------------------------------
    // UCE World Events
    // -----------------------------------------------------------------------------------
    class uce_worldevents
    {
        [PrimaryKey] // important for performance: O(log n) instead of O(n)
        public string name { get; set; }
        public int count { get; set; }
    }
#endif

    #endregion Custom Database Classes
}
