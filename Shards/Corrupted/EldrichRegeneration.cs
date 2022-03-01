using RogueLike.Players;

namespace RogueLike.Shards.Corrupted;

public class EldrichRegeneration : Shard
{
    public override void ResetPlayerEffects()
    {
        Owner.TotalLifeManaConversion = true;

        Owner.Player.statLife += Owner.Player.statMana;
        Owner.Player.statMana = 0;
    }

    public override bool CanAcquire(Rogue rogue)
    {
        return base.CanAcquire(rogue) && !rogue.TotalLifeManaConversion;
    }

    public override int Tier => TierCorrupt;
}