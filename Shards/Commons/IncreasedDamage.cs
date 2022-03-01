using Terraria.ModLoader;

namespace RogueLike.Shards.Commons;

public abstract class IncreasedDamage : Shard
{
    protected IncreasedDamage(int tier, float percentage)
    {
        Tier = tier;
        Percentage = percentage;
    }

    public override void ResetPlayerEffects()
    {
        Owner.Player.GetDamage(DamageClass.Generic) += Percentage;
    }

    public override string GetDescription(int count)
    {
        return string.Format(base.GetDescription(count), Percentage * 100);
    }

    public float Percentage { get; }

    public override int Tier { get; }
    public override string LocalizationKey { get; } = nameof(IncreasedDamage);
}

public class IncreasedDamageCommon : IncreasedDamage
{
    public IncreasedDamageCommon() : base(TierCommon, .01f)
    {
    }
}

public class IncreasedDamageRare : IncreasedDamage
{
    public IncreasedDamageRare() : base(TierRare, .02f)
    {
    }
}

public class IncreasedDamageElite : IncreasedDamage
{
    public IncreasedDamageElite() : base(TierElite, .03f)
    {
    }
}