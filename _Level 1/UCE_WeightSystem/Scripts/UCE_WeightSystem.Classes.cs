// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
// UCE WEIGHT SYSTEM

[System.Serializable]
public partial class UCE_WeightSystem
{
    public TargetBuffSkill burdenedBuff;
    public UCE_AttributeTemplate weightAttribute;
    public int carryPerPoint;
    public int maxBurdenLevel;
}
