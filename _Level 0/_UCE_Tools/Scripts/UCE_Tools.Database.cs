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

    // -----------------------------------------------------------------------------------
    // UCE_connection
    // @ workaround because uMMORPGs default database connection is private.
    // -----------------------------------------------------------------------------------
#if _SQLITE && _SERVER
    public SQLiteConnection UCE_connection {
		get {
			return connection;
		}
	}
#endif

}
