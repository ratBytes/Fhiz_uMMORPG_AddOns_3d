// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System;
using UnityEngine;
using Mirror;

// NetworkManagerMMO

public partial class NetworkManagerMMO
{
    // -----------------------------------------------------------------------------------
    // OnStartServer_UCE_GarbageCollector
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnStartServer")]
    private void OnStartServer_UCE_GarbageCollector()
    {
        Invoke("UCE_GarbageCollection", 3);
    }

    // -----------------------------------------------------------------------------------
    // OnServerDisconnect_UCE_GarbageCollector
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnServerDisconnect")]
    private void OnServerDisconnect_UCE_GarbageCollector(NetworkConnection conn)
    {
        if (Player.onlinePlayers.Count <= 1)
            UCE_GarbageCollection();
    }

    // -----------------------------------------------------------------------------------
    // UCE_GarbageCollection
    // -----------------------------------------------------------------------------------
    protected void UCE_GarbageCollection()
    {
        System.GC.Collect();
        Debug.Log("System Garbage Collection called...");
    }

    // -----------------------------------------------------------------------------------
}