// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

// SKILL STUB

[CreateAssetMenu(menuName = "UCE Skills/UCE Skill Stub", order = 999)]
public class UCE_SkillStub : ScriptableSkill
{
    public override bool CheckTarget(Entity entity)
    {
        return true;
    }

    public override bool CheckDistance(Entity caster, int skillLevel, out Vector3 destination)
    {
        destination = Vector3.zero;
        return true;
    }

    public override void Apply(Entity caster, int skillLevel)
    {
    }
}
