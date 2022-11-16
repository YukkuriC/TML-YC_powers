using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YC_powers.Skills
{
    public class ZenithRing : SkillOnce
    {
        const int DAMAGE = 400;

        public override void DoSkill()
        {
            int nproj = Main.rand.Next(10, 20),
                rdir = (Main.rand.Next(2) * 2 - 1) * Main.rand.Next(60, 200),
                rsize = 500;
            Vector2 dir = new Vector2(rsize * 0.5f, 0f).RotatedBy(Math.PI * 2 * Main.rand.NextDouble());
            int zType = Terraria.Graphics.FinalFractalHelper.GetRandomProfileIndex();
            for (int i = 0; i < nproj; i++)
            {
                Vector2 dv = dir.RotatedBy(Math.PI * 2 * i / nproj, default);
                Projectile.NewProjectile(
                    null,
                    Player.MountedCenter,
                    dv,
                    ProjectileID.FinalFractal, (int)Player.GetDamage(DamageClass.Melee).ApplyTo(DAMAGE), 10, Main.myPlayer,
                    (dv.X > 0 ? 1 : -1) * rdir,
                    zType
                );
            }
        }
    }
}
