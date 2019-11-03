// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using Mirror;

// UCE TIMEGATE

[System.Serializable]
public struct UCE_Timegate
{
    public string name;
    public int count;
    public string hours;
    public bool valid;
}

public class SyncListUCE_Timegate : SyncList<UCE_Timegate> { }