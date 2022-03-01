using RogueLike.Players;
using Terraria.DataStructures;

namespace RogueLike.Shards.Corrupted;

public class EnergyShield : Shard
{
    public override void ResetPlayerEffects()
    {
        Owner.TotalLifeManaConversion = true;
    }

    public override void PostResetPlayerEffects()
    {
        const int maxLife = 3;

        Owner.Player.statManaMax2 += Owner.Player.statLifeMax2 - maxLife;

        if (Owner.Player.statLife > maxLife)
            Owner.Player.statMana += Owner.Player.statLife - maxLife;

        Owner.Player.statLife = maxLife;
    }

    public override bool PreHurtPlayer(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage,
        ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
    {
        if (Owner.Player.statMana >= damage)
        {
            Owner.Player.statMana -= damage;
            damage = 0;
        }
        else
        {
            var dmg = damage;

            damage -= Owner.Player.statMana;
            Owner.Player.statMana -= dmg;
        }

        return true;
    }

    public override void UpdatePlayerLifeRegen()
    {
        Owner.Player.manaRegen += Owner.Player.lifeRegen;
    }

    public override void UpdatePlayerEquips()
    {
        Owner.Player.manaFlower = false;
    }

    public override bool CanAcquire(Rogue rogue)
    {
        return base.CanAcquire(rogue) && !rogue.TotalLifeManaConversion;
    }

    public override int Tier => TierCorrupt;
}