using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RogueLike.Shards;
using Terraria;
using WebmilioCommons.Extensions;
using WebmilioCommons.Players;

namespace RogueLike.Players;

public partial class Rogue : BetterModPlayer
{
    private readonly List<Shard> _shards = new();

    public void AddShard(Shard shard)
    {
        if (shard.Unique && _shards.Contains(shard))
            return;

        shard.Owner = this;
        shard.OnAcquire();

        if (_shards.Count == 0 || shard.Order == 0)
        {
            _shards.Insert(0, shard);
        }
        else
        {
            for (int i = _shards.Count - 1; i >= 0 && shard != null; --i)
            {
                if (shard.Order >= _shards[i].Order)
                {
                    _shards.Insert(i + 1, shard);
                    shard = null;
                }
            }
        }
    }

    public void RemoveShard(Shard shard)
    {
        _shards.Remove(shard);

        shard.OnLost();
        shard.Owner = default;
    }

    public bool HasShard(Type type) => _shards.FindIndex(p => p.GetType() == type) != -1;

    public bool HasShard(Shard shard) => _shards.Contains(shard);


    public void ForShard(Action<Shard> action) => _shards.Do(action);

    public bool ForShard(Predicate<Shard> predicate)
    {
        for (int i = 0; i < _shards.Count; i++)
            if (!predicate(_shards[i]))
                return false;

        return true;
    }


    public static Rogue Get() => Get(Main.LocalPlayer);
    public static Rogue Get(Player player) => player.GetModPlayer<Rogue>();

    public ReadOnlyCollection<Shard> Shards => _shards.AsReadOnly();
}