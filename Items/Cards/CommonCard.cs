using Terraria.ID;

namespace RogueLike.Items.Cards;

public class CommonCard : Card
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;
    }
}