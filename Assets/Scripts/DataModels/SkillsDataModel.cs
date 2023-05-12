using System;
using System.Linq;
using System.Collections.Generic;

namespace DataModels
{
    public class SkillsDataModel
    {
        private List<SkillData> skillData = new List<SkillData>();

        public StateSkill GetStateSkill(string keiSkill) => GetSkill(keiSkill).stateSkill;

        public void SetStateSkill(string keiSkill, StateSkill stateSkill)
        {
            var skill = GetSkill(keiSkill);
            skill.stateSkill = stateSkill;
        }

       

        public SkillData GetSkill(string keySkill)
        {
            var skill = skillData.FirstOrDefault(x => x.keySkill == keySkill);
            if (skill == null)
            {
                skill = new SkillData() {keySkill = keySkill};
                skillData.Add(skill);
            }

            return skill;
        }
    }

    [Serializable]
    public class SkillData
    {
        public string keySkill;
        public StateSkill stateSkill; 
        public int incomingPurchasedNodesCount;
    }
}