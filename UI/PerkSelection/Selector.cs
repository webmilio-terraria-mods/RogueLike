using System.Collections.Generic;
using Microsoft.Xna.Framework;
using RogueLike.Shards;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using WebmilioCommons.Extensions;

namespace RogueLike.UI.PerkSelection;

public class Selector : UIPanel
{
    private readonly Color _color = new(.1f, .1f, .1f);
    private ShardEntry[] _entries;

    public void BuildList(IList<Shard> perks)
    {
        RemoveAllChildren();

        //_entries?.Do(e => e.OnClick -= Entry_OnClick);
        _entries = new ShardEntry[perks.Count];

        perks.Do(delegate(Shard perk, int i)
        {
            ShardEntry entry = new(perk)
            {
                Top = new(0, .33f * i),

                Width = StyleDimension.Fill,
                Height = new(0, .32f),

                BackgroundColor = _color,
                BorderColor = Color.Transparent
            };

            entry.OnClick += Entry_OnClick;
            Append(entry);

            _entries[i] = entry;
        });
    }

    private static void Entry_OnClick(UIMouseEvent evt, UIElement element)
    {
        ModContent.GetInstance<RogueUI>().SelectPerk(((ShardEntry)element).Shard);
    }
}