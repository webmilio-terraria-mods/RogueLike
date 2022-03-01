using Microsoft.Xna.Framework;
using RogueLike.Players;
using Terraria;
using Terraria.DataStructures;
using WebmilioCommons.Items;

namespace RogueLike.Items;

public class RogueGlobalItem : BetterGlobalItem
{
    public override bool Shoot(Item item, Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity,
        int type, int damage, float knockback)
    {
        return Rogue.Get(player).ForShard(p =>
            p.Shoot(item, source, ref position, ref velocity, ref type, ref damage, ref knockback));
    }
}