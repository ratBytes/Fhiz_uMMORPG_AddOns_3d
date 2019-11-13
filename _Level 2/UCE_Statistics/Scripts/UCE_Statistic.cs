// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using Mirror;
using System;
using UnityEngine;

// UCE_Statistic

[Serializable]
public partial struct UCE_Statistic
{
    public string name;
    public long amount;
    public long total;
}

public class SyncListUCE_Statistic : SyncList<UCE_Statistic> { }
