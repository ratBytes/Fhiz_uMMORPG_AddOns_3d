// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

// TemplateDefines

[CreateAssetMenu(menuName = "UCE Other/UCE Defines", fileName = "UCE_Defines", order = 999)]
public partial class UCE_TemplateDefines : ScriptableObject
{
	
	static UCE_TemplateDefines _instance;

	[SerializeField]
	public List<UCE_DefinesAddOn> defines = new List<UCE_DefinesAddOn>();

	[Serializable]
	public partial class UCE_DefinesAddOn
	{
		[HideInInspector]public string name;
		public bool active;
	}
   	
    // -----------------------------------------------------------------------------------
    // OnValidate
    // -----------------------------------------------------------------------------------
    void OnValidate()
    {
#if UNITY_EDITOR
     	
     	if (UCE_DefinesManager.defines.Count() > 0 && defines.Count() != UCE_DefinesManager.defines.Count()-1 )
        {

            defines.Clear();

            // -- build list from defines
            for(int i = 0; i < UCE_DefinesManager.defines.Count(); ++i)
            {
                if (UCE_DefinesManager.defines[i] == "_iMMOTOOLS" || UCE_DefinesManager.defines[i] == "_iMMOCORE") continue;

                UCE_DefinesAddOn addon = new UCE_DefinesAddOn();
                addon.name = UCE_DefinesManager.defines[i];
                addon.active = UCE_DefinesManager.active[i];
                defines.Add(addon);
            }

        } else {

            // -- copy list to defines
            for (int i = 0; i < defines.Count(); ++i)
            {

                if (UCE_DefinesManager.active[i] == defines[i].active) continue;

                UCE_DefinesManager.active[i] = defines[i].active;

                if (!defines[i].active)
                    UCE_EditorTools.RemoveScriptingDefine(defines[i].name);
                else
                    UCE_EditorTools.AddScriptingDefine(defines[i].name);

            }

        }
             	
#endif
    }

    // -----------------------------------------------------------------------------------
    // Singleton
    // -----------------------------------------------------------------------------------
    public static UCE_TemplateDefines singleton
    {
        get 
        {
            if (!_instance)
                _instance = Resources.FindObjectsOfTypeAll<UCE_TemplateDefines>().FirstOrDefault();
            return _instance;
        }
    }


    // -----------------------------------------------------------------------------------
}
