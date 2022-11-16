using Terraria;
using Terraria.ModLoader;
using System.Reflection;

namespace YC_powers.Commands
{
    internal class CmdSpawnItem : ModCommand
    {
        public override string Command => "item";
        public override string Description => "Create item into player's inventory";
        public override string Usage => base.Usage + " type [count=maxStack]";

        public override CommandType Type => CommandType.Chat;

        MethodInfo pickupFunc;

        public override void Load()
        {
            pickupFunc = typeof(Player).GetMethod("PickupItem", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (caller.Player != Main.LocalPlayer) return;
            if (args.Length >= 1 && int.TryParse(args[0], out int type))
            {
                int count;
                if (args.Length < 2 || !int.TryParse(args[1], out count)) count = 32767;
                var item = Main.item[Main.item.Length - 1];
                item.SetDefaults(type);
                item.stack = count;
                pickupFunc.Invoke(caller.Player, new object[] { Main.myPlayer, Main.item.Length - 1, item });
            }
        }
    }
}
