using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ID;

namespace YC_powers.PlayerPowers
{
    internal class RespawnController : ModPlayer
    {
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (Config.Instance.ShortRespawnTimer) Player.respawnTimer = Math.Min(Player.respawnTimer, 300);
        }
    }
}
