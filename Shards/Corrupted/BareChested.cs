using System;
using WebmilioCommons;

namespace RogueLike.Shards.Corrupted;

public class BareChested : Shard
{
    private const float 
        Ratio = .1f,
        Uninterruptible = .5f,
        CalculatedRatio = Ratio * Uninterruptible;

    private FloatToIntBuffer _regen;

    public override void OnAcquire()
    {
        _regen = new(delegate(int b)
        {
            Owner.Player.statLife += b;
            Owner.Player.lifeRegen += b * 2;
        });
    }

    public override void UpdatePlayerLifeRegen()
    {
        const float ratio = CalculatedRatio / Constants.TicksPerSecond;
        _regen.Value += Owner.Player.statDefense * ratio;

        Owner.Player.statDefense = 0;
    }

    public override string GetDescription(int count)
    {
        return string.Format(base.GetDescription(count), 
            Ratio * 100, MathF.Round(Owner.Player.statDefense * Ratio, 2), Uninterruptible * 100);
    }

    public override int Tier => TierCorrupt;
}