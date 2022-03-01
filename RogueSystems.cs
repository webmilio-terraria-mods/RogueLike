using RogueLike.Players;
using RogueLike.Shards;
using RogueLike.UI;
using Terraria.ModLoader;

namespace RogueLike;

public class RogueSystems : ModSystem
{
    private readonly ShardsHelper _shards;

    public RogueSystems()
    {
        _shards = RogueLike.Instance.Services.GetService<ShardsHelper>();
    }

    public override void PostUpdateInput()
    {
        var rogueUI = ModContent.GetInstance<RogueUI>();

        if (RogueLike.Instance.Debug1.JustPressed)
        {
            rogueUI.ShardSelectionLayer.State.Build(_shards.GetRandom(Rogue.Get(), Shard.TierRare, 3));
            rogueUI.ShardSelectionLayer.IsVisible = !rogueUI.ShardSelectionLayer.IsVisible;
        }

        if (RogueLike.Instance.Debug2.JustPressed)
        {
            rogueUI.CatalogLayer.State.Build(Rogue.Get().Shards);
            rogueUI.CatalogLayer.IsVisible = !rogueUI.CatalogLayer.IsVisible;
        }
    }
}