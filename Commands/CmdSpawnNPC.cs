using Terraria;
using Terraria.ModLoader;
using System.Reflection;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace YC_powers.Commands
{
    internal class CmdSpawnNPC : ModCommand
    {
        public override string Command => "npc";
        public override string Description => "Create npc at player's cursor";
        public override string Usage => base.Usage + " type [count=1]";

        public override CommandType Type => CommandType.Chat;

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (caller.Player != Main.LocalPlayer) return;
            if (args.Length >= 1 && int.TryParse(args[0], out int type))
            {
                int count;
                if (args.Length < 2 || !int.TryParse(args[1], out count)) count = 1;

                Vector2 pos = Main.MouseWorld;
                for (int i = 0; i < count; i++)
                {
                    if (Main.netMode == NetmodeID.SinglePlayer) NPC.NewNPC(null, (int)pos.X, (int)pos.Y, type);
                    else NetMessage.SendData(MessageID.FishOutNPC, -1, -1, null, (int)pos.X / 16, pos.Y / 16, type);
                }
            }
        }
    }
}
