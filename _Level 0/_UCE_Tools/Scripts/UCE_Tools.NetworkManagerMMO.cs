// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

// NetworkManagerMMO

public partial class NetworkManagerMMO
{
    public enum DatabaseType { SQLite, mySQL }

    [Header("Configuration")]
    public UCE_TemplateConfiguration configTemplate;

    [Header("Database Type")]
    public DatabaseType databaseType = DatabaseType.SQLite;

    // uses Suriyun Editor tools to toggle visiblity of the following fields
    // those fields are only visible when mySQL is selected

    [StringShowConditional(conditionFieldName: "databaseType", conditionValue: "mySQL")]
    public string dbHost = "localhost";

    [StringShowConditional(conditionFieldName: "databaseType", conditionValue: "mySQL")]
    public string dbName = "dbName";

    [StringShowConditional(conditionFieldName: "databaseType", conditionValue: "mySQL")]
    public string dbUser = "dbUser";

    [StringShowConditional(conditionFieldName: "databaseType", conditionValue: "mySQL")]
    public string dbPassword = "dbPassword";

    [StringShowConditional(conditionFieldName: "databaseType", conditionValue: "mySQL")]
    public uint dbPort = 3306;

    [StringShowConditional(conditionFieldName: "databaseType", conditionValue: "mySQL")]
    public string dbCharacterSet = "utf8mb4";

    protected const string DB_SQLITE = "_SQLITE";
    protected const string DB_MYSQL = "_MYSQL";

    // -----------------------------------------------------------------------------------
    // OnValidate
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnValidate")]
    private void OnValidate_UCE_Tools()
    {
#if UNITY_EDITOR
        if (databaseType == NetworkManagerMMO.DatabaseType.SQLite)
        {
            UCE_EditorTools.RemoveScriptingDefine(DB_MYSQL);
            UCE_EditorTools.AddScriptingDefine(DB_SQLITE);
        }
        else if (databaseType == NetworkManagerMMO.DatabaseType.mySQL)
        {
            UCE_EditorTools.RemoveScriptingDefine(DB_SQLITE);
            UCE_EditorTools.AddScriptingDefine(DB_MYSQL);
        }
#endif
    }

    // -----------------------------------------------------------------------------------
    // Start_UCE_Tools
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Start")]
    private void Start_UCE_Tools()
    {
#if _SERVER && !_CLIENT
        StartServer();
#endif
    }

    // -----------------------------------------------------------------------------------
}
