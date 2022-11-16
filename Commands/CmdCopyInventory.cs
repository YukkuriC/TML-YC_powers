using Terraria;
using Terraria.ModLoader;

namespace YC_powers.Commands
{
    internal class CmdCopyInventory : ModCommand
    {
        public override string Command => "copy";
        public override string Description => "Copy certain player's inventory whose name or id matches provided param; or list all server players if no param provided";
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

            // do copy
            CopyItems(target.inventory, myself.inventory);
            CopyItems(target.armor, myself.armor);
            CopyItems(target.miscEquips, myself.miscEquips);
            caller.Reply($"Copy complete from {target.name}");
        }

        void CopyItems(Item[] from, Item[] to)
        {
            for (var i = 0; i < from.Length; i++)
            {
                to[i] = new Item(from[i].type, from[i].stack, from[i].prefix);
            }
        }
    }
}
