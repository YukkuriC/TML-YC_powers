using Terraria;
using Terraria.ModLoader;
using System.Reflection;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace YC_powers.Commands
{
    internal class CmdKillMe : ModCommand
    {
        public override string Command => "killme";
        public override string Description => "Suicide with provided message";
        public override string Usage => base.Usage + " [message to display]";

        public override CommandType Type => CommandType.Chat;

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (caller.Player != Main.LocalPlayer) return;
            var reason = PlayerDeathReason.ByOther(8);
            if (args.Length > 0) reason = PlayerDeathReason.ByCustomReason(string.Join(' ', args));
            caller.Player.KillMe(reason, 114514, caller.Player.direction, true);
        }
    }
}
