namespace RogueLike.Players;

public partial class Rogue
{
    private void StatsResetEffects()
    {
        MaxHealthPerc = -0.5f;
        MaxHealthRegenPerc = 0;

        TotalLifeManaConversion = false;
    }

    private void StatsPostResetEffects()
    {
        Player.statLifeMax2 += (int)(Player.statLifeMax * MaxHealthPerc);
    }

    public float MaxHealthPerc { get; set; }
    public float MaxHealthRegenPerc { get; set; }

    public bool TotalLifeManaConversion { get; set; }
}