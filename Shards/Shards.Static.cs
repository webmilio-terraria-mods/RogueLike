using Microsoft.Xna.Framework;

namespace RogueLike.Shards;

public partial class Shard
{
    public static Color GetStandardBorder(int tier)
    {
        switch (tier)
        {
            case TierCommon:
                return ColorCommon;
            case TierRare:
                return ColorRare;
            case TierElite:
                return ColorElite;
            case TierCorrupt:
                return ColorCorrupt;
            case TierLegendary:
                return ColorLegendary;
        }

        return default;
    }
}