using Terraria.ID;

namespace RogueLike.Items.Cards;

public class CorruptCard : Card
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Orange;
    }
}