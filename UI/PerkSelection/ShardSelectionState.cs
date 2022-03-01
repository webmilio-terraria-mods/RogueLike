using System.Collections.Generic;
using Microsoft.Xna.Framework;
using RogueLike.Shards;
using Terraria;
using Terraria.UI;

namespace RogueLike.UI.PerkSelection;

public class ShardSelectionState : UIState
{
    private readonly Selector _selector;

    public ShardSelectionState()
    {
        Append(_selector = new()
        {
            Width = new(0, .5f),
            Height = new(0, .60f),

            HAlign = .5f,
            VAlign = .5f,

            BackgroundColor = new(.05f, .05f, .05f, .99f)
        });
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (ContainsPoint(Main.MouseScreen))
        {
            Main.blockMouse = true;
        }
    }

    public void Build(IList<Shard> perks)
    {
        _selector.BuildList(perks);
    }
}