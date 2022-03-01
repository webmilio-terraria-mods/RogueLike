using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace RogueLike.Players;

public partial class Rogue
{
    public override void ResetEffects()
    {
        StatsResetEffects();
        ForShard(perk => perk.ResetPlayerEffects());
        StatsPostResetEffects();
        ForShard(perk => perk.PostResetPlayerEffects());
    }

    public override void ModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        StatModifier rDamage = damage;
        float rFlat = flat;

        ForShard(perk => perk.ModifyPlayerWeaponDamage(item, ref rDamage, ref rFlat));

        flat = rFlat;
        damage = rDamage;
    }

    public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage,
        ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
    {
        int rDamage = damage;
        int rHitDirection = hitDirection;
        bool rCrit = crit;
        bool rCustomDamage = customDamage;
        bool rPlaySound = playSound;
        bool rGenGore = genGore;
        PlayerDeathReason rDamageSource = damageSource;

        var result = ForShard(perk => perk.PreHurtPlayer(pvp, quiet, ref rDamage, ref rHitDirection, ref rCrit,
            ref rCustomDamage, ref rPlaySound, ref rGenGore, ref rDamageSource));

        damageSource = rDamageSource;
        genGore = rGenGore;
        playSound = rPlaySound;
        customDamage = rCustomDamage;
        crit = rCrit;
        hitDirection = rHitDirection;
        damage = rDamage;

        return result;
    }

    public override void PreUpdate()
    {
        ForShard(perk => perk.PreUpdatePlayer());
    }

    public override void UpdateEquips() => ForShard(perk => perk.UpdatePlayerEquips());

    public override void UpdateLifeRegen() => ForShard(perk => perk.UpdatePlayerLifeRegen());
}