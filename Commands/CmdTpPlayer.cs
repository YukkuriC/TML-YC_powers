using Terraria;
using Terraria.ModLoader;

namespace YC_powers.Commands
{
    internal class CmdTpPlayer : ModCommand
    {
        public override string Command => "tp";
        public override string Description => "Teleport to certain player whose name or id matches provided param; or list all server players if no param provided";
        public override string Usage => base.Usage + " [plr_id/plr_name]";

        public override CommandType Type => CommandType.Chat;

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            var myself = caller.Player;
            if (myself != Main.LocalPlayer) return;
            if (args.Length == 0)
            {
                Helpers.DoQuery(caller, input, null);
                return;
            }
            if (args.Length > 1)
            {
                caller.Reply("Usage: " + Usage);
                return;
            }
            // filter player
            var target = Helpers.GetPlayerByString(args[0]);
            if (target == null)// fail
            {
                caller.Reply($"Failed to find such player: {args[0]}");
                return;
            }

            caller.Player.UnityTeleport(target.position);
            caller.Reply($"Teleported to {target.name}");
        }
    }
}
