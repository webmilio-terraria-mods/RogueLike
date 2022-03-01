namespace RogueLike.Shards.Commons;

public abstract class IncreasedDefense : Shard
{
    protected IncreasedDefense(int tier, int defense)
    {
        Tier = tier;
        Defense = defense;
    }

    public override void ResetPlayerEffects()
    {
        Owner.Player.statDefense += Defense;
    }

    public override string GetDescription(int count)
    {
        return string.Format(base.GetDescription(count), Defense);
    }

    public int Defense { get; }

    public override int Tier { get; }
    public override string LocalizationKey { get; } = nameof(IncreasedDefense);
}

public class IncreasedDefenseCommon : IncreasedDefense
{
    public IncreasedDefenseCommon() : base(TierCommon, 1)
    {
    }
}

public class IncreasedDefenseRare : IncreasedDefense
{
    public IncreasedDefenseRare() : base(TierRare, 2)
    {
    }
}

public class IncreasedDefenseElite : IncreasedDefense
{
    public IncreasedDefenseElite() : base(TierElite, 3)
    {
    }
}