using Terraria.ID;

namespace RogueLike.Items.Cards;

public class LegendaryCard : Card
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Purple;
    }
}