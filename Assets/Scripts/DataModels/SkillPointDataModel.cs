using System;

namespace DataModels
{
    public class SkillPointDataModel
    {
        public event Action OnChangeSkillPoints;
        
        private int _skillPointCount = 0;

        public int GetSkillPoint() => _skillPointCount;
        public void AppendSkillPoint(int countAppend) => _skillPointCount += countAppend;
        public void SpendSkillPoint(int countSpend) => _skillPointCount -= countSpend;
    }
}