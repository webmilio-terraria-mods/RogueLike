using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;
using WebmilioCommons;
using WebmilioCommons.DependencyInjection;
using WebmilioCommons.Inputs;

namespace RogueLike;

public class RogueLike : Mod
{
    public RogueLike()
    {
        Instance = this;

        Services.MapServices(typeof(RogueLike).Assembly);
        WebmilioCommonsMod.CommonServices.AddContainer(Services);
    }

    public override void Load()
    {
        KeybindAttribute.RegisterKeybinds(this);
    }

    public override void Unload()
    {
        WebmilioCommonsMod.CommonServices.RemoveProvider(Services);
        Services = default;
    }

    [Keybind("Debug1", Keys.OemSemicolon)] public ModKeybind Debug1 { get; set; }
    [Keybind("Debug2", Keys.OemPeriod)] public ModKeybind Debug2 { get; set; }

    public SimpleServices Services { get; private set; } = new();
    public static RogueLike Instance { get; private set; }
}