using Terraria.ID;

namespace RogueLike.Items.Cards;

public class RareCard : Card
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Green;
    }
}