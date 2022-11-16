namespace YC_powers.Skills
{
    public class SkillContinuous : Skill
    {
        public virtual void DoSkill(int t) { }
        public virtual int SkillLength => 60;
        int timer;
        public SkillContinuous()
        {
            timer = 0;
        }
        public override void Update()
        {
            if (isActive)
            {
                DoSkill(timer++);
                if (timer > SkillLength)
                    isActive = false;
            }
        }
    }
}
