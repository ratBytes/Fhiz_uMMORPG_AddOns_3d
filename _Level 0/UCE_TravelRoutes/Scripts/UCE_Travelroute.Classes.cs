// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using Mirror;

// TRAVELROUTE - CLASS

[System.Serializable]
public struct UCE_TravelrouteClass
{
    public string name;

    public UCE_TravelrouteClass(string _name)
    {
        name = _name;
    }
}

public class SyncListUCE_TravelrouteClass : SyncList<UCE_TravelrouteClass> { }