using Microsoft.Xna.Framework;
using RogueLike.Shards;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using WebmilioCommons.Helpers;

namespace RogueLike.UI;

public class ShardEntry : UIPanel
{
    private readonly Color _colorDiff = new(.05f, .05f, .05f);
    private Color _originalBorder;

    private readonly UIPanel _imagePanel;
    private readonly UIPanel _textPanel;
    private readonly UIText _description;

    public ShardEntry(Shard shard) : this(shard, 1) { }

    public ShardEntry(Shard shard, int count)
    {
        Shard = shard;

        SetPadding(20);
        const float imageWidth = .18f;

        Append(_imagePanel = new()
        {
            Height = StyleDimension.Fill
        });

        {
            _textPanel = new()
            {
                Height = StyleDimension.Fill,
                Width = new(0, .5f),

                BackgroundColor = Color.Transparent,
                BorderColor = Color.Transparent,
            };

            _textPanel.SetPadding(2.5f);

            Append(_textPanel);

            _textPanel.Append(new UIText(Shard.GetName(), 1.25f));
            _textPanel.Append(_description = new(Shard.GetDescription(count), 1)
            {
                Top = new(35, 0),
                Left = new(3, 0),

                Width = StyleDimension.Fill,

                TextOriginX = 0,

                IsWrapped = true,
            });

            if (count > 1)
            {
                _textPanel.Append(new UIText($"x{count}")
                {
                    HAlign = 1,
                    VAlign = 1,

                    Left = new(-50, 0)
                });
            }
        }
    }

    public override void OnInitialize()
    {
        base.OnInitialize();

        _originalBorder = BorderColor;
    }

    public override void Recalculate()
    {
        base.Recalculate();

        var dimensions = GetDimensions();

        var imageDimensions = _imagePanel.GetDimensions();
        _imagePanel.Width.Pixels = imageDimensions.Height;

        _textPanel.Left = new(PaddingLeft + imageDimensions.Width, 0);

        var width = dimensions.Width - imageDimensions.Width - 10;
        _textPanel.Width = new(width, 0);
        _description.Width = new(width * .65f, 0);
    }

    public override void MouseOver(UIMouseEvent evt)
    {
        ColorHelpers.Add(ref BackgroundColor, _colorDiff);
        BorderColor = Shard.BorderColor;

        base.MouseOver(evt);
    }

    public override void MouseOut(UIMouseEvent evt)
    {
        BorderColor = _originalBorder;
        ColorHelpers.Substract(ref BackgroundColor, _colorDiff);

        base.MouseOut(evt);
    }

    public Shard Shard { get; }
}