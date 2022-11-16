using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;

namespace YC_powers
{
    public class ModMain : Mod
    {
        internal static ModKeybind keyTeleport, keyZenithRing, keyMissile, keyFlame;
        public static ModMain instance;

        public override void Load()
        {
            instance = this;
            keyTeleport = KeybindLoader.RegisterKeybind(this, "Teleport to cursor", "F");
            keyZenithRing = KeybindLoader.RegisterKeybind(this, "Fire a ring of Zenith blades", "G");
            keyMissile = KeybindLoader.RegisterKeybind(this, "Fire rainbow missiles", Keys.LeftShift);
            keyFlame = KeybindLoader.RegisterKeybind(this, "Fire a field of flaming area", "G");
        }
    }
}