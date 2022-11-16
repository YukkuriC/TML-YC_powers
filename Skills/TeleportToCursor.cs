using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace YC_powers.Skills
{
    public class TeleportToCursor : SkillOnce
    {
        const int TELEPORT_STYLE = 10;
        const int TELEPORT_CD = 10;

        public override int SkillCD => TELEPORT_CD;
        public override void DoSkill()
        {
            var target = Main.MouseWorld - Player.MountedCenter + Player.position;
            Player.Teleport(target, TELEPORT_STYLE);
            Player.fallStart = Player.fallStart2 = (int)(Player.position.Y / 16f);
            NetMessage.SendData(MessageID.Teleport, -1, -1, null, 0, Main.myPlayer, target.X, target.Y, TELEPORT_STYLE, 0, 0);
        }
    }
}
