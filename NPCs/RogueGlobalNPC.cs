using RogueLike.Players;
using Terraria;
using WebmilioCommons.NPCs;

namespace RogueLike.NPCs;

public class RogueGlobalNPC : BetterGlobalNPC
{
    public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
    {
        int rDamage = damage;
        float rKnockback = knockback;
        bool rCrit = crit;

        Rogue.Get(player).ForShard(perk => perk.ModifyNPCHitByItem(npc, item, ref rDamage, ref rKnockback, ref rCrit));

        crit = rCrit;
        knockback = rKnockback;
        damage = rDamage;
    }
}