using Terraria;

namespace YC_powers.Skills
{
    public class Skill
    {
        public bool isActive = true;
        public Player Player => Main.LocalPlayer;
        public virtual void Update()
        {
            throw new System.Exception("fuck");
        }
        public virtual int SkillCD => 60;
    }
}
