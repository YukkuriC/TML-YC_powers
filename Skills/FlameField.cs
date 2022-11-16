using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace YC_powers.Skills
{
    public class FlameField : SkillContinuous
    {
        const int DAMAGE = 250;
        const int DIST = 120;
        const float ANGLE = 0.25f;

        public override int SkillCD => 60;
        public override int SkillLength => 80;

        Vector2 src;
        float shootDir;

        public override void DoSkill(int t)
        {
            if (t == 0)
            {
                src = Player.Center;
                var dVec = Main.MouseWorld - src;
                shootDir = MathF.Atan2(dVec.Y, dVec.X);
            }
            for (int i = 0; i < 5; i++)
            {
                if (t == (i + 1) * 15 - 14)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        float dDir = ANGLE * (-i * 0.5f + j) + shootDir;
                        Projectile.NewProjectile(null,
                            src + new Vector2(MathF.Cos(dDir), MathF.Sin(dDir)) * DIST * i,
                            Vector2.Zero,
                            ProjectileID.InfernoFriendlyBlast,
                            (int)Player.GetDamage(DamageClass.Ranged).ApplyTo(DAMAGE),
                            10f,
                            Player.whoAmI
                        );
                    }
                }
            }
        }
    }
}
