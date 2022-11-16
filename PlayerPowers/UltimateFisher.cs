using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace YC_powers.PlayerPowers
{
    internal class UltimateFisher : ModPlayer
    {
        int fishingCnt;
        MethodInfo methodCheckBobber, methodPullBobber;

        public UltimateFisher()
        {
            // init reflection
            methodCheckBobber = typeof(Player).GetMethod("ItemCheck_CheckFishingBobber_PickAndConsumeBait", BindingFlags.NonPublic | BindingFlags.Instance);
            methodPullBobber = typeof(Player).GetMethod("ItemCheck_CheckFishingBobber_PullBobber", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public override void PostUpdate()
        {
            if (Player.whoAmI != Main.myPlayer) return;
            if (Config.Instance.FishingSpamming)
            {
                fishingCnt++;
                if (fishingCnt >= 5)
                {
                    fishingCnt -= 5;
                    if (Player.inventory[Player.selectedItem].fishingPole == 0 || Player.CCed || Player.noItems || Player.pulley)
                    {
                        return;
                    }
                    Projectile.NewProjectile(null, Player.MountedCenter,
                        Utils.RandomVector2(Main.rand, 0, 3) + new Vector2(Player.direction * 10, 0f),
                        Player.inventory[Player.selectedItem].shoot,
                        0, 0f, Player.whoAmI);
                }
            }
            if (Config.Instance.FishingCollect)
            {
                foreach (var projectile in Main.projectile)
                {
                    if (projectile.active && projectile.owner == Player.whoAmI && projectile.bobber && projectile.ai[0] == 0f && projectile.ai[1] != 0f)
                    {
                        projectile.ai[0] = 1f;
                        float num = -10f;
                        if (projectile.wet && projectile.velocity.Y > num)
                        {
                            projectile.velocity.Y = num;
                        }
                        projectile.netUpdate2 = true;
                        if (projectile.ai[1] < 0f && projectile.localAI[1] != 0f)
                        {
                            var args = new object[] { projectile, false, 0 }; // proj, out bool, out int
                            methodCheckBobber.Invoke(Player, args);
                            if ((bool)args[1]) methodPullBobber.Invoke(Player, new object[] { projectile, args[2] });
                        }
                    }
                }
            }
        }
    }
}
