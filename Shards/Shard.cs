using Microsoft.Xna.Framework;
using RogueLike.Players;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Commons;
using WebmilioCommons.Extensions;

namespace RogueLike.Shards;

public abstract partial class Shard : IIdentifiable<string>, IModLinked
{
    public static readonly Color
        ColorCommon = new(157, 157, 157),
        ColorRare = new(21, 190, 48),
        ColorElite = new(249, 14, 0),
        ColorLegendary = new(143, 0, 255),
        ColorCorrupt = new(20, 20, 20);

    public const int
        TierCommon = ItemRarityID.White,
        TierRare = ItemRarityID.Green,
        TierElite = ItemRarityID.LightRed,
        TierLegendary = ItemRarityID.Purple,
        TierCorrupt = ItemRarityID.Red;

    public virtual bool CanAcquire(Rogue rogue)
    {
        return !Unique || !rogue.HasShard(GetType());
    }

    public virtual float ChanceMultiplier(Rogue rogue)
    {
        return 1;
    }

    public virtual void OnAcquire() { }
    public virtual void OnLost() { }


    public virtual void ResetPlayerEffects() { }
    public virtual void PostResetPlayerEffects() { }

    public virtual void ModifyNPCHitByItem(NPC npc, Item item, ref int damage, ref float knockback, ref bool crit) { }
    public virtual void ModifyPlayerWeaponDamage(Item item, ref StatModifier damage, ref float flat) { }

    public virtual bool PreHurtPlayer(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
        ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) => true;

    public virtual void PreUpdatePlayer() { }

    public virtual bool Shoot(Item item, ProjectileSource_Item_WithAmmo source, ref Vector2 position,
        ref Vector2 velocity, ref int type, ref int damage, ref float knockback) => true;

    public virtual void UpdatePlayerEquips() { }
    public virtual void UpdatePlayerLifeRegen() { }


    public virtual string GetName() => Mod.GetText($"Perks.{LocalizationKey}.Name").Value;
    public virtual string GetDescription(int count) => Mod.GetText($"Perks.{LocalizationKey}.Description").Value;

    public virtual string Identifier => GetType().Name;
    public virtual string LocalizationKey => Identifier;

    public abstract int Tier { get; }
    public virtual Color BorderColor => GetStandardBorder(Tier);

    public virtual bool Unique { get; }
    public virtual bool Group => true;

    public Mod Mod { get; set; }
    public Rogue Owner { get; set; }

    public virtual ushort Order { get; } = 0;
}