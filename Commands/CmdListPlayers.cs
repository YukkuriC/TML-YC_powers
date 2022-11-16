using Terraria.ModLoader;

namespace YC_powers.Commands
{
    internal class CmdListPlayers : ModCommand
    {
        public override string Command => "ls";
        public override string Description => "List all active players";

        public override CommandType Type => CommandType.Chat;

        public override void Action(CommandCaller caller, string input, string[] args) => Helpers.DoQuery(caller, input, args);
    }
}
