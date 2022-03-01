using Terraria;

namespace RogueLike.Shards.Legendary.BreakerBlade;

public class ILikeAChallenge : Shard
{
    public override void ModifyNPCHitByItem(NPC npc, Item item, ref int damage, ref float knockback, ref bool crit)
    {
        var delta = Owner.Player.statDefense - npc.defense;

        if (delta <= 0)
            return;

        damage += delta * 3;
    }

    public override int Tier => TierLegendary;
}