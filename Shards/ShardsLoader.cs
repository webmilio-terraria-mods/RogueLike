using System.Collections.Generic;
using System.Collections.ObjectModel;
using Terraria.ModLoader;
using WebmilioCommons.DependencyInjection;
using WebmilioCommons.Extensions;
using WebmilioCommons.Loaders;

namespace RogueLike.Shards;

[Service]
public class ShardsLoader : PrototypeLoader<Shard>
{
    private readonly Dictionary<int, ReadOnlyCollection<Shard>> _tiers;

    public ShardsLoader()
    {
        Load();

        Dictionary<int, List<Shard>> tiers = new();

        ForAllGeneric(delegate (Shard perk)
        {
            tiers.AddOrGet(perk.Tier, out var ts, () => new());

            ts.Add(perk);
        });

        _tiers = tiers.ToReadOnlyListDictionary();
    }

    protected override void PostAdd(Mod mod, Shard shard)
    {
        shard.Mod = mod;
    }

    public bool TryGetPerks(int tier, out ReadOnlyCollection<Shard> perks) => _tiers.TryGetValue(tier, out perks);
}