using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ID;

namespace YC_powers.PlayerPowers
{
    internal class DamageAbsorber : ModPlayer
    {
        const float DMG_TAX_STEP = 20;
        const float ANGER_MULT = 0.005f;
        const float ANGER_DECAY = 0.1f;
        float anger = 0;

        public override void Initialize()
        {
            anger = 0;
        }
        public override void PostUpdate()
        {
            anger = Math.Max(0, anger - ANGER_DECAY);
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
        {
            if (!(Player.whoAmI != Main.myPlayer && Config.Instance.ReduceDamage)) return true;
            float taxFactor = crit ? 2f : 1f;
            float dmgBefore = damage, dmgAfter = 0;
            while (dmgBefore > 0)
            {
                float step = Math.Min(DMG_TAX_STEP, dmgBefore);
                dmgAfter += step / taxFactor;
                dmgBefore -= step;
                taxFactor++;
            }
            damage = (int)dmgAfter;
            return true;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit, int cooldownCounter)
        {
            if (Player.whoAmI != Main.myPlayer) return;
            if (Config.Instance.ConvertDamage)
            {
                anger += (float)damage;
            }
        }
        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            damage *= 1 + anger * ANGER_MULT;
        }
    }
}
