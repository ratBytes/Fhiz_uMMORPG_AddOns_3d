// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using Mirror;
using UnityEngine;

// ===================================================================================
// UCE INTERACTABLE CLASS
// ===================================================================================
[RequireComponent(typeof(NetworkIdentity))]
public abstract partial class UCE_Interactable : NetworkBehaviour
{
    [Header("[-=-=-=- UCE INTERACTABLE -=-=-=-]")]
    public SpriteRenderer interactionSpriteRenderer;
    public string interactionText = "Interact with this Object";
    public Sprite interactionIcon;
    public bool automaticActivation;

    public UCE_InteractionRequirements interactionRequirements;

    protected UCE_UI_InteractableAccessRequirement instance;

    [SyncVar, HideInInspector] public bool unlocked = false;

    [Tooltip("Only needed if using automatic activation.")]
    [Header("-=-=-=- Configureable Labels -=-=-=-")]
    public string labelMinLevel = " Minimum Level: ";
    public string labelMaxLevel = " Maximum Level: ";

    public string labelMinHealth = " Min. Health Percent: ";
    public string labelMinMana = " Min. Mana Percent: ";

    public string labelDayStart = " Start Day: ";
    public string labelDayEnd = " End Day: ";
    public string labelActiveMonth = " Active Month: ";

    public string labelRequiredSkills = " Skill(s): ";
    public string labelLevel = "LV";
    public string labelAllowedClasses = " Allowed Class(es): ";
    public string labelRequiresGuild = " Guild Membership";
    public string labelRequiresParty = " Party Membership";
#if _iMMOPRESTIGECLASSES
    public string labelAllowedPrestigeClasses = " Allowed Prestige Class(es): ";
#endif
#if _iMMOPVP
    public string labelRequiresRealm = " Limited to Specific Realm";
#endif
    public string labelRequiresQuest = " Quest: ";
    public string labelInProgressQuest = "[Must be in progress]";
#if _iMMOFACTIONS
    public string labelFactionRequirements = " Faction Ratings: ";
#endif

    public string labelRequiredEquipment = " Equipment: ";
    public string labelRequiredItems = " Item(s): ";
    public string labelDestroyItem = "[Destroyed on use]";
#if _iMMOHARVESTING
    public string requiredHarvestProfessions = " Harvesting Profession(s): ";
#endif
#if _iMMOCRAFTING
    public string requiredCraftProfessions = " Craft Profession(s): ";
#endif
#if _iMMOMOUNTS
    public string labelMountedOnly = " Accessible only while mounted.";
    public string labelUnmountedOnly = " Accessible only while unmounted.";
#endif
#if _iMMOTRAVEL
    public string labelTravelroute = " Travelroute: ";
#endif
#if _iMMOWORLDEVENTS
	public string labelWorldEvent 					= " World Event: ";
#endif
#if _iMMOGUILDUPGRADES
	public string labelGuildUpgrades 				= " Guild Level: ";
#endif
#if _iMMOACCOUNTUNLOCKABLES
	public string labelAccountUnlockable			= " Account Unlockable: ";
#endif

    public ChannelInfo requires = new ChannelInfo("", "(Requires)", "(Requires)", null);

    // -----------------------------------------------------------------------------------
    // Start
    // -----------------------------------------------------------------------------------
    public virtual void Start()
    {
        if (interactionIcon != null && interactionSpriteRenderer != null)
            interactionSpriteRenderer.sprite = interactionIcon;
    }

    // -----------------------------------------------------------------------------------
    // OnInteractClient
    // -----------------------------------------------------------------------------------
    //[ClientCallback]
    public virtual void OnInteractClient(Player player) { }

    // -----------------------------------------------------------------------------------
    // OnInteractServer
    // -----------------------------------------------------------------------------------
    //[ServerCallback]
    public virtual void OnInteractServer(Player player) { }

    // -----------------------------------------------------------------------------------
    // IsUnlocked
    // -----------------------------------------------------------------------------------
    public virtual bool IsUnlocked() { return false; }

    // -----------------------------------------------------------------------------------
    // ConfirmAccess
    // @Client
    // -----------------------------------------------------------------------------------
    public virtual void ConfirmAccess()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (interactionRequirements.checkRequirements(player) || IsUnlocked())
        {
            OnInteractClient(player);
            player.Cmd_UCE_OnInteractServer(this.gameObject);
        }
        else
        {
            if (automaticActivation)
                UpdateRequirementChat();
        }
    }

    // -----------------------------------------------------------------------------------
    // Update Required Chat (Auto Activation)
    // @Client
    // -----------------------------------------------------------------------------------
    protected virtual void UpdateRequirementChat()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        // -- Requirements

        if (interactionRequirements.minLevel > 0)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelMinLevel + interactionRequirements.minLevel.ToString(), "", requires.textPrefab));

        if (interactionRequirements.maxLevel > 0)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelMaxLevel + interactionRequirements.maxLevel.ToString(), "", requires.textPrefab));

        if (interactionRequirements.minHealth > 0)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelMinHealth + interactionRequirements.minHealth.ToString(), "", requires.textPrefab));

        if (interactionRequirements.minMana > 0)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelMinMana + interactionRequirements.minMana.ToString(), "", requires.textPrefab));

        //TIME
        if (interactionRequirements.dayStart > 0)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelDayStart + interactionRequirements.dayStart.ToString(), "", requires.textPrefab));

        if (interactionRequirements.dayEnd > 0)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelDayEnd + interactionRequirements.dayEnd.ToString(), "", requires.textPrefab));

        if (interactionRequirements.activeMonth > 0)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelActiveMonth + interactionRequirements.activeMonth.ToString(), "", requires.textPrefab));

        if (interactionRequirements.requiredSkills.Length > 0)
        {
            foreach (UCE_SkillRequirement skill in interactionRequirements.requiredSkills)
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelRequiredSkills + skill.skill.name + labelLevel + skill.level.ToString(), "", requires.textPrefab));
        }

        if (interactionRequirements.allowedClasses.Length > 0)
        {
            string temp_classes = "";
            foreach (GameObject classes in interactionRequirements.allowedClasses)
                temp_classes += " " + classes.name;
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelAllowedClasses + temp_classes, "", requires.textPrefab));
        }

        if (interactionRequirements.requiresParty)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelRequiresParty, "", requires.textPrefab));

        if (interactionRequirements.requiresGuild)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelRequiresGuild, "", requires.textPrefab));

#if _iMMOPRESTIGECLASSES
        if (interactionRequirements.allowedPrestigeClasses.Length > 0)
        {
            string temp_classes = "";
            foreach (UCE_PrestigeClassTemplate classes in interactionRequirements.allowedPrestigeClasses)
                temp_classes += " " + classes.name;
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelAllowedPrestigeClasses + temp_classes, "", requires.textPrefab));
        }
#endif

#if _iMMOPVP
        if (interactionRequirements.requiredRealm != null && interactionRequirements.requiredAlly != null)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelRequiresRealm, "", requires.textPrefab));
#endif

#if _iMMOQUESTS
        if (interactionRequirements.requiredQuest != null)
        {
            if (!interactionRequirements.questMustBeInProgress)
            {
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelRequiresQuest + interactionRequirements.requiredQuest.name, "", requires.textPrefab));
            }
            else
            {
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelRequiresQuest + interactionRequirements.requiredQuest.name + labelInProgressQuest, "", requires.textPrefab));
            }
        }
#else
        if (interactionRequirements.requiredQuest != null)
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelRequiresQuest + interactionRequirements.requiredQuest.name, "", requires.textPrefab));
#endif

#if _iMMOFACTIONS
        if (interactionRequirements.factionRequirements.Length > 0)
        {
            foreach (UCE_FactionRequirement factionRequirement in interactionRequirements.factionRequirements)
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelFactionRequirements + factionRequirement.faction.name, "", requires.textPrefab));
        }
#endif

        if (interactionRequirements.requiredEquipment.Length > 0)
        {
            foreach (EquipmentItem item in interactionRequirements.requiredEquipment)
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelRequiredEquipment + item.name, "", requires.textPrefab));
        }

        if (interactionRequirements.requiredItems.Length > 0)
        {
            foreach (UCE_ItemRequirement item in interactionRequirements.requiredItems)
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelRequiredItems + item.item.name, "", requires.textPrefab));
        }

#if _iMMOHARVESTING
        if (interactionRequirements.harvestProfessionRequirements.Length > 0)
        {
            foreach (UCE_HarvestingProfessionRequirement prof in interactionRequirements.harvestProfessionRequirements)
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, requiredHarvestProfessions + prof.template.name + " " + labelLevel + prof.level, "", requires.textPrefab));
        }
#endif

#if _iMMOCRAFTING
        if (interactionRequirements.craftProfessionRequirements.Length > 0)
        {
            foreach (UCE_CraftingProfessionRequirement prof in interactionRequirements.craftProfessionRequirements)
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, requiredCraftProfessions + prof.template.name + " " + labelLevel + prof.level, "", requires.textPrefab));
        }
#endif

#if _iMMOMOUNTS
        if (interactionRequirements.mountType == UCE_Requirements.MountType.Mounted)
        {
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelMountedOnly, "", requires.textPrefab));
        }
        else if (interactionRequirements.mountType == UCE_Requirements.MountType.Unmounted)
        {
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelUnmountedOnly, "", requires.textPrefab));
        }
#endif

#if _iMMOTRAVEL
        if (!string.IsNullOrWhiteSpace(interactionRequirements.requiredTravelrouteName))
        {
            UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelTravelroute + interactionRequirements.requiredTravelrouteName, "", requires.textPrefab));
        }
#endif

#if _iMMOWORLDEVENTS
		if (interactionRequirements.worldEvent != null)
		{
			if (player.UCE_CheckWorldEvent(interactionRequirements.worldEvent, interactionRequirements.minEventCount, interactionRequirements.maxEventCount))
			{
				if (interactionRequirements.maxEventCount == 0)
                    UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelWorldEvent + interactionRequirements.worldEvent.name + " (" + player.UCE_GetWorldEventCount(interactionRequirements.worldEvent) + "/" + interactionRequirements.minEventCount.ToString() + ")", "", requires.textPrefab));
				else
                    UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelWorldEvent + interactionRequirements.worldEvent.name + " (" + interactionRequirements.minEventCount.ToString() + "-" + interactionRequirements.maxEventCount.ToString() + ") [" + player.UCE_GetWorldEventCount(interactionRequirements.worldEvent) + "]", "", requires.textPrefab));
            }
            else
            {
            	if (interactionRequirements.maxEventCount == 0)
                    UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelWorldEvent + interactionRequirements.worldEvent.name + " (" + player.UCE_GetWorldEventCount(interactionRequirements.worldEvent) + "/" + interactionRequirements.minEventCount.ToString() + ")", "", requires.textPrefab));
				else
                    UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelWorldEvent + interactionRequirements.worldEvent.name + " (" + interactionRequirements.minEventCount.ToString() + "-" + interactionRequirements.maxEventCount.ToString() + ") [" + player.UCE_GetWorldEventCount(interactionRequirements.worldEvent) + "]", "", requires.textPrefab));
            }
		}
#endif

#if _iMMOGUILDUPGRADES
		if (interactionRequirements.minGuildLevel > 0)
		{
			if (player.InGuild())
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelGuildUpgrades + player.guildLevel.ToString() + "/" + interactionRequirements.minGuildLevel.ToString(), "", requires.textPrefab));
			else
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelGuildUpgrades + "0/" + interactionRequirements.minGuildLevel.ToString(), "", requires.textPrefab));
		}
#endif

#if _iMMOACCOUNTUNLOCKABLES
		if (!string.IsNullOrWhiteSpace(interactionRequirements.accountUnlockable))
		{
			if (player.UCE_HasAccountUnlock(interactionRequirements.accountUnlockable))
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelAccountUnlockable + interactionRequirements.accountUnlockable, "", requires.textPrefab));
			else
                UIChat.singleton.AddMessage(new ChatMessage("", requires.identifierIn, labelAccountUnlockable + interactionRequirements.accountUnlockable, "", requires.textPrefab));
		}
#endif
    }

    // -----------------------------------------------------------------------------------
    // ShowAccessRequirementsUI
    // @Client
    // -----------------------------------------------------------------------------------
    protected virtual void ShowAccessRequirementsUI()
    {
        if (instance == null)
            instance = FindObjectOfType<UCE_UI_InteractableAccessRequirement>();

        instance.Show(this);
    }

    // -----------------------------------------------------------------------------------
    // HideAccessRequirementsUI
    // @Client
    // -----------------------------------------------------------------------------------
    protected void HideAccessRequirementsUI()
    {
        if (instance == null)
            instance = FindObjectOfType<UCE_UI_InteractableAccessRequirement>();

        instance.Hide();
    }

    // -----------------------------------------------------------------------------------
    // IsWorthUpdating
    // -----------------------------------------------------------------------------------
    public virtual bool IsWorthUpdating()
    {
        return netIdentity.observers == null ||
               netIdentity.observers.Count > 0;
    }

    // -----------------------------------------------------------------------------------
}
