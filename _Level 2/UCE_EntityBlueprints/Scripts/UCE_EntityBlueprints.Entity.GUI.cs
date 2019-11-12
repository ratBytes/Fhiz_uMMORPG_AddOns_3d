// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;
using System.Collections;
using UnityEditor;

#if UNITY_EDITOR

[CustomEditor(typeof(Monster))]
public class MonsterEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Monster entity = (Monster)target;
        if (GUILayout.Button("Apply Blueprints"))
        {
            entity.ApplyBlueprints();
        }
    }
}

#endif
