using System;

namespace DataModels
{
    public class SkillPointDataModel
    {
        public event Action OnChangeSkillPoints;

        private int _skillPointCount;

        public int GetSkillPoint() => _skillPointCount;

        public void AppendSkillPoint(int countAppend)
        {
            _skillPointCount += countAppend;
            OnChangeSkillPoints?.Invoke();
        }

        public void SpendSkillPoint(int countSpend)
        {
            _skillPointCount -= countSpend;
            OnChangeSkillPoints?.Invoke();
        }
    }
}