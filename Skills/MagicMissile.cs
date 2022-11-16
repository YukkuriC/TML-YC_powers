using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YC_powers.Skills
{
    public class MagicMissile : SkillOnce
    {
        static readonly int[] MISSILE_POOL = new int[]
        {
            ProjectileID.MagicMissile,
            ProjectileID.Flamelash,
            ProjectileID.RainbowRodBullet,
        };

        public override int SkillCD => 1200 / Player.statManaMax;
        public override void DoSkill()
        {
            var shootDir = Vector2.Normalize(Main.MouseWorld - Player.Center) * 5f;
            var proj = Projectile.NewProjectileDirect(
                null, Player.Center, shootDir, MISSILE_POOL[Main.rand.Next(MISSILE_POOL.Length)],
                (int)Player.GetDamage(DamageClass.Magic).ApplyTo(Player.statLifeMax),
                10,
                Main.myPlayer
            );
            proj.rotation = MathF.Atan2(shootDir.Y, shootDir.X);
        }
    }
}
