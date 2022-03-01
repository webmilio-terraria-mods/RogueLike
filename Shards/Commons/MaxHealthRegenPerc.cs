namespace RogueLike.Shards.Commons;

public abstract class MaxHealthRegenPerc : Shard
{
    private const float Uninterruptible = .2f;

    protected MaxHealthRegenPerc(int tier, float percentage)
    {
        Tier = tier;

        Percentage = percentage;
    }

    public override void ResetPlayerEffects()
    {
        Owner.MaxHealthRegenPerc += Percentage;
        Owner.Player.statLife += (int) (Percentage * Uninterruptible * Owner.Player.statLifeMax2);
    }

    public override void UpdatePlayerLifeRegen()
    {
        Owner.Player.lifeRegen += (int) (Owner.Player.statLifeMax2 * Percentage * (1 - Uninterruptible));
    }


    public override string GetDescription(int count)
    {
        return string.Format(base.GetDescription(count),
            Percentage * 100, Owner.Player.statLifeMax * Percentage, Uninterruptible * 100);
    }

    public float Percentage { get; }

    public override int Tier { get; }
    public override string LocalizationKey { get; } = nameof(MaxHealthRegenPerc);
    public override ushort Order => 1;
}

public class MaxHealthRegenPercRare : MaxHealthRegenPerc
{
    public MaxHealthRegenPercRare() : base(TierRare, .00125f)
    {
    }

    public override string Identifier { get; } = nameof(MaxHealthRegenPercRare);
}

public class MaxHealthRegenPercElite : MaxHealthRegenPerc
{
    public MaxHealthRegenPercElite() : base(TierElite, .0025f)
    {
    }

    public override string Identifier { get; } = nameof(MaxHealthRegenPercElite);
}