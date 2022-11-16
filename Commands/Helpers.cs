using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace YC_powers.Commands
{
    internal class Helpers
    {
        public static void DoQuery(CommandCaller caller, string input, string[] args)
        {
            if (caller.Player != Main.LocalPlayer) return;
            var res = new List<string>();
            foreach (var plr in Main.player)
            {
                if (!plr.active) continue;
                res.Add($"#{plr.whoAmI}:{plr.name}");
            }
            caller.Reply("All players:");
            caller.Reply(string.Join("; ", res));
        }
        public static Player GetPlayerByString(string param)
        {
            if (int.TryParse(param, out int plrId))// by id
            {
                if (plrId >= 0 && plrId < Main.player.Length)
                {
                    var p = Main.player[plrId];
                    if (p.active) return p;
                }
            }
            foreach (var p in Main.player)
            {
                if (p.active && p.name == param)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
