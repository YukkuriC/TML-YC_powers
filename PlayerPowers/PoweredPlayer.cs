using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using YC_powers.Skills;

namespace YC_powers.PlayerPowers
{
    internal class PoweredPlayer : ModPlayer
    {
        List<Skill> skillPool, skillPoolAlt;

        int skillTimer;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Player.whoAmI != Main.myPlayer) return;

            // update use skill
            if (skillTimer > 0) skillTimer--;
            if (skillTimer <= 0 && !Player.dead)
            {
                Skill skillAppending = null;

                // decide skill to use
                if (ModMain.keyTeleport.JustPressed)
                    skillAppending = new TeleportToCursor();
                else if (ModMain.keyZenithRing.JustPressed)
                    skillAppending = new ZenithRing();
                else if (ModMain.keyMissile.Current)
                    skillAppending = new MagicMissile();
                else if (ModMain.keyFlame.JustPressed)
                    skillAppending = new FlameField();

                // append skill
                if (skillAppending != null)
                {
                    skillTimer = skillAppending.SkillCD;
                    if (skillPool == null) skillPool = new List<Skill>();
                    skillPool.Add(skillAppending);
                }
            }

            // update skills
            if (skillPool == null || skillPool.Count == 0) return;
            if (skillPoolAlt == null) skillPoolAlt = new List<Skill>();
            else skillPoolAlt.Clear();
            foreach (var skill in skillPool)
            {
                skill.Update();
                if (skill.isActive) skillPoolAlt.Add(skill);
            }
            var oldAlt = skillPool;
            skillPool = skillPoolAlt;
            skillPoolAlt = oldAlt;
        }
    }
}
