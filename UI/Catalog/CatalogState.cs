using Microsoft.Xna.Framework;
using RogueLike.Players;
using RogueLike.Shards;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using WebmilioCommons.Extensions;

namespace RogueLike.UI.Catalog;

public class CatalogState : UIState
{
    private readonly UIList _list;

    public CatalogState()
    {
        UIPanel container;

        Append(container = new()
        {
            Width = new(0, .5f),
            Height = new(0, .8f),

            HAlign = .5f,
            VAlign = .5f,

            BackgroundColor = new(.1f, .1f, .1f)
        });

        {
            container.Append(_list = new()
            {
                Width = new(0, .95f),
                Height = StyleDimension.Fill,
            });

            UIScrollbar scrollbar;
            container.Append(scrollbar = new()
            {
                Height = StyleDimension.Fill,
                Width = new(20, 0),

                HAlign = 1
            });

            _list.SetScrollbar(scrollbar);
        }
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (ContainsPoint(Main.MouseScreen))
        {
            Main.blockMouse = true;
        }
    }

    public void Build(IReadOnlyCollection<Shard> shards)
    {
        _list.Clear();

        StyleDimension height = new(250, 0);

        foreach (var group in CreateList(shards))
        {
            _list.Add(new ShardEntry(group.shard, group.count)
            {
                Height = height,
                Width = StyleDimension.Fill,
                BackgroundColor = new(.05f, .05f, .05f, .99f)
            });
        }
    }

    public static List<ShardGrouping> CreateList(IReadOnlyCollection<Shard> shards)
    {
        Dictionary<int, List<Shard>> grouped = new();

        foreach (var shard in shards)
        {
            grouped.AddOrGet(shard.Tier, out var lShards, () => new());
            lShards.Add(shard);
        }

        var ordered = grouped.OrderByDescending(kv => kv.Key);

        Dictionary<string, ShardGrouping> types = new();
        List<ShardGrouping> groupings = new();

        foreach (var kv in ordered)
        {
            List<ShardGrouping> tierShards = new();

            foreach (var shard in kv.Value)
            {
                if (!shard.Group)
                {
                    tierShards.Add(new(shard));
                }
                else if (!types.ContainsKey(shard.Identifier))
                {
                    tierShards.Add(new(shard));
                    types.Add(shard.Identifier, tierShards[^1]);
                }
                else
                {
                    ++types[shard.Identifier].count;
                }

                tierShards.Sort(new Comparison<ShardGrouping>((x, y) => x.count < y.count ? 1 : -1));
            }

            groupings.AddRange(tierShards);
        }

        return groupings;
    }

    public class ShardGrouping
    {
        public Shard shard;
        public int count;

        public ShardGrouping(Shard shard)
        {
            this.shard = shard;
            this.count = 1;
        }

        public ShardGrouping(Shard shard, int count)
        {
            this.shard = shard;
            this.count = count;
        }
    }
}