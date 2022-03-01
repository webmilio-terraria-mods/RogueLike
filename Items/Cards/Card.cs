using Terraria.ID;

namespace RogueLike.Items.Cards;

public abstract class Card : RogueItem
{
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.headSlot = 30;

        Item.maxStack = 999;

        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = Item.useAnimation = 60;
    }

    public bool Prototype { get; init; }
}