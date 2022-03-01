using Microsoft.Xna.Framework;
using System.Collections.Generic;
using RogueLike.Players;
using RogueLike.Shards;
using RogueLike.UI.Catalog;
using RogueLike.UI.PerkSelection;
using Terraria.ModLoader;
using Terraria.UI;
using WebmilioCommons.UI;

namespace RogueLike.UI;

public class RogueUI : ModSystem
{
    public override void Load()
    {
        ShardSelectionLayer = new(new(), nameof(ShardSelectionLayer), InterfaceScaleType.UI);
        CatalogLayer = new(new(), nameof(CatalogLayer), InterfaceScaleType.UI);
    }

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        ShardSelectionLayer.ModifyInterfaceLayers(layers);
        CatalogLayer.ModifyInterfaceLayers(layers);
    }

    public override void UpdateUI(GameTime gameTime)
    {
        ShardSelectionLayer.Update(gameTime);
        CatalogLayer.Update(gameTime);
    }

    public void SelectPerk(Shard shard)
    {
        ShardSelectionLayer.IsVisible = false;
        Rogue.Get().AddShard(shard);
    }

    public UILayer<ShardSelectionState> ShardSelectionLayer { get; private set; }
    public UILayer<CatalogState> CatalogLayer { get; private set; }
}