namespace YC_powers.Skills
{
    public class SkillOnce : Skill
    {
        public virtual void DoSkill() {
            throw new System.Exception("?");
        }
        public override void Update()
        {
            if (isActive)
            {
                DoSkill();
                isActive = false;
            }
        }
    }
}
