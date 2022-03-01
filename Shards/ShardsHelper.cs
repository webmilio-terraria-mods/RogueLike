using System.Collections.Generic;
using RogueLike.Players;
using Terraria;
using WebmilioCommons.DependencyInjection;
using WebmilioCommons.Extensions;

namespace RogueLike.Shards;

[Service]
public class ShardsHelper
{
    private readonly ShardsLoader _shards;

    public ShardsHelper(ShardsLoader shards)
    {
        _shards = shards;
    }

    public List<Shard> GetRandom(Rogue rogue, int tier, int count)
    {
        if (!_shards.TryGetPerks(tier, out var perks))
            return new();

        List<Shard> result = new();

        foreach (var prototype in GetRandomPrototypes(rogue, perks, count))
        {
            var perk = _shards.New(prototype);
            perk.Owner = rogue;

            result.Add(perk);
        }

        return result;
    }

    private static IEnumerable<Shard> GetRandomPrototypes(Rogue rogue, IList<Shard> perks, int count)
    {
        List<Shard> available = new(perks);

        available.DoInverted(delegate (Shard perk, int index)
        {
            if (!perk.CanAcquire(rogue))
                available.RemoveAt(index);
        });

        if (available.Count <= count)
        {
            for (int i = 0; i < available.Count; ++i)
                yield return available[i];
        }
        else
        {
            for (int i = 0; i < count; ++i)
            {
                int index = Main.rand.Next(0, available.Count);
                yield return available[index];

                available.RemoveAt(index);
            }
        }
    }
}