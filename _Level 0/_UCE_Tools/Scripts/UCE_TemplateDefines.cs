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

[CreateAssetMenu(menuName = "UCE Other/UCE Defines", fileName = "New UCE Defines", order = 999)]
public partial class UCE_TemplateDefines : ScriptableObject
{
	
	static UCE_TemplateDefines _instance;

	[SerializeField]
	public List<UCE_DefinesAddOn> defines = new List<UCE_DefinesAddOn>();
	
	[Serializable]
	public partial class UCE_DefinesAddOn
	{
		public string name;
		public bool active;
	}
   	
    // -----------------------------------------------------------------------------------
    // OnValidate
    // -----------------------------------------------------------------------------------
    public void OnValidate()
    {
#if UNITY_EDITOR
     	
     	// save first?
     	
     	defines.Clear();
     	
     	for (int i = 0; i < UCE_DefinesManager.defines.Count(); ++i)
     	{
     		UCE_DefinesAddOn addon 	= new UCE_DefinesAddOn();
     		addon.name 				= UCE_DefinesManager.defines[i];
     		addon.active 			= UCE_DefinesManager.active[i];
     		defines.Add(addon);
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
