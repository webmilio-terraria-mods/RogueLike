using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace RogueLike.Shards.Legendary.SeedWeapons;

public class TripleShot : Shard
{
    public override bool Shoot(Item item, ProjectileSource_Item_WithAmmo source, ref Vector2 position, ref Vector2 velocity,
        ref int type, ref int damage, ref float knockback)
    {
        if (source.AmmoItemIdUsed != ItemID.Seed)
            return true;

        for (int i = 0; i < Main.rand.Next(1, 4); ++i)
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, source.Player.whoAmI);

        return true;
    }
    
    public override int Tier => TierLegendary;

    public override bool Unique => false;
}