// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

// ENTITY

public partial class Entity
{
    [HideInInspector] public UCE_Area_WaveSpawner UCE_parentSpawnArea;
    [HideInInspector] public int UCE_parentWaveIndex;

    // -----------------------------------------------------------------------------------
    // OnDeath
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnDeath")]
    private void OnDeath_UCE_WaveSpawnerEntity()
    {
        if (UCE_parentSpawnArea == null) return;
        UCE_parentSpawnArea.updateMemberPopulation(name.GetDeterministicHashCode(), UCE_parentWaveIndex);
        UCE_parentSpawnArea = null;
    }

    // -----------------------------------------------------------------------------------
}
