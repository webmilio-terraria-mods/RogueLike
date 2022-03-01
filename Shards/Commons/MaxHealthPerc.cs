namespace RogueLike.Shards.Commons;

public abstract class MaxHealthPerc : Shard
{
    protected MaxHealthPerc(int tier, float percentage)
    {
        Tier = tier;
        Percentage = percentage;
    }

    public override void ResetPlayerEffects()
    {
        Owner.MaxHealthPerc += Percentage;
    }

    public override string GetDescription(int count)
    {
        return string.Format(base.GetDescription(count), 
            Percentage * 100 * count, (int) (Owner.Player.statLifeMax * Percentage * count));
    }

    public float Percentage { get; }

    public override int Tier { get; }
    public override string LocalizationKey { get; } = nameof(MaxHealthPerc);
}

public class MaxHealthPercIncreaseCommon : MaxHealthPerc
{
    public MaxHealthPercIncreaseCommon() : base(TierCommon, .02f)
    {
    }
}

public class MaxHealthPercIncreaseRare : MaxHealthPerc
{
    public MaxHealthPercIncreaseRare() : base(TierRare, .04f)
    {
    }
}

public class MaxHealthPercIncreaseElite : MaxHealthPerc
{
    public MaxHealthPercIncreaseElite() : base(TierElite, .08f)
    {
    }
}