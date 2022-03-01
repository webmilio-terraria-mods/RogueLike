using Terraria.ID;

namespace RogueLike.Items.Cards;

public class EliteCard : Card
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Red;
    }
}